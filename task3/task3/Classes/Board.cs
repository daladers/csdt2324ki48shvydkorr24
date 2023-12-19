namespace task3.Classes
{
    public class Board : ICloneable
    {
        public int[,] Gameboard { get; set; }
        public bool IsWhiteTurn { get; private set; }
        public bool IsJump { get; private set; }
        public bool IsNextJump { get; private set; }
        public bool IsWin { get; private set; }

        private int[] _whitePieces = new int[2] { 2, 4 };
        private int[] _blackPieces = new int[2] { 1, 3 };
        private static int _boardSize = 8;

        public List<Point[]> ListMoves = new List<Point[]>();
        public Player PlayerWhite;
        public Player PlayerBlack;
        enum Pieces
        {
            Empty,
            BlackPawn,
            WhitePawn,
            BlackKing,
            WhiteKing
        }

        public Board(bool isWhiteTurn) // default constructor
        {
            PlayerWhite = new Player(Setting.Player1Name, _whitePieces);
            PlayerBlack = new Player(Setting.Player2Name, _blackPieces);

            Gameboard = new int[8, 8] {
                { 0,1,0,1,0,1,0,1 },
                { 1,0,1,0,1,0,1,0 },
                { 0,1,0,1,0,1,0,1 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 2,0,2,0,2,0,2,0 },
                { 0,2,0,2,0,2,0,2 },
                { 2,0,2,0,2,0,2,0 }
            };
            IsWhiteTurn = isWhiteTurn;
            IsJump = false;

        }
        public Board(int[,] gameboard, int whitePawnsLeft, int blackPawnsLeft, int whiteKingsLeft, int blackKingsLeft) // custom constructor for custom board
        {
            int[] whitePieces = new int[2] { 2, 4 };
            int[] blackPieces = new int[2] { 1, 3 };
            Gameboard = gameboard;
            PlayerWhite = new Player("Player 1", whitePieces, whitePawnsLeft, whiteKingsLeft);
            PlayerBlack = new Player("Player 2", blackPieces, blackPawnsLeft, blackKingsLeft);
            IsWhiteTurn = true;
            IsJump = false;
        }
        public Board(Player playerWhite, Player playerBlack) // constructor for deep copy object
        {
            PlayerWhite = playerWhite;
            PlayerBlack = playerBlack;
        }

        public void changePlayerTurn()
        {
            IsWhiteTurn ^= true;
            IsJump = false;
        }

        public bool isPLayerWin(Player player)
        {
            if (player.Score == 12)
                return true;
            else
                return false;
        }

        public void checkAllMoves(int color)
        {
            int[] playerColors = GetColors(color, false);
            ListMoves.Clear();
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (playerColors.Contains(Gameboard[x, y]))
                    {
                        Point[] availableMoves = checkAvailableMoves(new Point(x, y));
                        if (availableMoves[0].X + availableMoves[0].Y > 0)
                        {
                            foreach (Point p in availableMoves)
                            {
                                if (p.X + p.Y > 0)
                                {
                                    Point[] piece = new Point[2];
                                    piece[0] = new Point(x, y);
                                    piece[1] = p;
                                    ListMoves.Add(piece);
                                }
                            }
                        }
                    }
                }
            }
            if (Setting.ForceJump == true)
                checkJump();
        }

        private void checkJump()
        {
            List<Point[]> tmpList = new List<Point[]>();
            foreach (Point[] move in ListMoves)
            {
                Point[] tmpMoves = new Point[2];
                if (Math.Pow(move[0].X - move[1].X, 2) > 2)
                {
                    tmpMoves[0] = move[0];
                    tmpMoves[1] = move[1];
                    tmpList.Add(tmpMoves);
                    IsJump = true;
                }
            }
            if (IsJump == true)
                ListMoves = tmpList;
        }

        private void NextJump(Point selectedPiece)
        {
            IsNextJump = false;
            List<Point[]> tmpList = new List<Point[]>();
            Point[] availableMoves = checkAvailableMoves(new Point(selectedPiece.X, selectedPiece.Y));
            foreach (var move in availableMoves)
            {
                if (move.IsEmpty == false && Math.Pow(move.X - selectedPiece.X, 2) > 2)
                {
                    IsNextJump = true;
                    Point[] piece = new Point[2];
                    piece[0] = selectedPiece;
                    piece[1] = move;
                    tmpList.Add(piece);
                }
            }
            if (IsNextJump == true)
                ListMoves = tmpList;
            else
                IsNextJump = false;
        }

        public void MakeMove(Point selectedPiece, Point newPosition)
        {
            if (Math.Pow(newPosition.X - selectedPiece.X, 2) > 2) // jump
            {
                addScore(Gameboard[(newPosition.X + selectedPiece.X) / 2, (newPosition.Y + selectedPiece.Y) / 2]);
                Gameboard[newPosition.X, newPosition.Y] = Gameboard[selectedPiece.X, selectedPiece.Y];
                Gameboard[selectedPiece.X, selectedPiece.Y] = (int)Pieces.Empty;
                Gameboard[(newPosition.X + selectedPiece.X) / 2, (newPosition.Y + selectedPiece.Y) / 2] = (int)Pieces.Empty;
                NextJump(newPosition);
            }
            else // move
            {
                Gameboard[newPosition.X, newPosition.Y] = Gameboard[selectedPiece.X, selectedPiece.Y];
                Gameboard[selectedPiece.X, selectedPiece.Y] = (int)Pieces.Empty;
            }
            UpgradeToKing(new Point(newPosition.X, newPosition.Y));
            if (IsNextJump == false)
                changePlayerTurn();
        }

        private void UpgradeToKing(Point actualPosition) // check is piece change to king
        {
            int color = Gameboard[actualPosition.X, actualPosition.Y];
            if (color == (int)Pieces.WhitePawn && actualPosition.X == 0)
            {
                Gameboard[actualPosition.X, actualPosition.Y] = (int)Pieces.WhiteKing;
                PlayerWhite.AddKing();
            }
            else if (color == (int)Pieces.BlackPawn && actualPosition.X == _boardSize - 1)
            {
                Gameboard[actualPosition.X, actualPosition.Y] = (int)Pieces.BlackKing;
                PlayerWhite.AddKing();
            }
        }

        private void addScore(int piece) // add score for capture opponent piece
        {
            if (piece == (int)Pieces.BlackPawn || piece == (int)Pieces.BlackKing)
            {
                if (piece == (int)Pieces.BlackKing)
                    PlayerBlack.CaptureKing();
                else
                    PlayerBlack.CapturePawns();
                PlayerWhite.IncreaseScore();
            }
            else
            {
                if (piece == (int)Pieces.WhiteKing)
                    PlayerWhite.CaptureKing();
                else
                    PlayerWhite.CapturePawns();
                PlayerBlack.IncreaseScore();
            }
            if (PlayerWhite.Score == 12 || PlayerBlack.Score == 12)
                IsWin = true;
        }

        private Point[] addMove(Point[] moves, Point move)
        {
            Point[] tmp = moves;
            for (int i = 0; i < moves.Length; i++)
            {
                if (moves[i].X + moves[i].Y == 0)
                {
                    moves[i] = move;
                    break;
                }
            }
            return moves;
        }

        private bool IsKing(int color) // return is piece is king or pawn
        {
            if (color == (int)Pieces.BlackKing || color == (int)Pieces.WhiteKing)
                return true;
            else
                return false;
        }

        private int[] GetColors(int color, bool isOppnent) // get player or opponent colors
        {
            if (isOppnent == false)
            {
                if (PlayerWhite.PlayerColors.Contains(color))
                    return PlayerWhite.PlayerColors;
                else
                    return PlayerBlack.PlayerColors;
            }
            else
            {
                if (PlayerWhite.PlayerColors.Contains(color))
                    return PlayerBlack.PlayerColors;
                else
                    return PlayerWhite.PlayerColors;
            }
        }

        private bool checkIsMoveOutOfBounds(int X, int Y)
        {
            bool result = false;
            if (X < 0 || X > _boardSize - 1) // check is out of bounds on up || down side
                result = true;
            if (Y < 0 || Y > _boardSize - 1) // check is out of bounds on left || right side
                result = true;
            return result;
        }

        private Point[] checkAvailableMoves(Point SelectedPlace)
        {
            int color = Gameboard[SelectedPlace.X, SelectedPlace.Y];        // get piece color id;
            bool king = IsKing(color);
            int[] opponent = GetColors(color, true);

            Point[] moves = king == true ? new Point[4] : new Point[2]; // if piece == king then moves = 4 else moves = 2

            if (color == (int)Pieces.WhitePawn || king == true)     // check move place for white piece or king piece
            {
                if (checkIsMoveOutOfBounds(SelectedPlace.X - 1, SelectedPlace.Y - 1) == false)      // check is left-up place is out of bounds board
                {
                    if (Gameboard[SelectedPlace.X - 1, SelectedPlace.Y - 1] == (int)Pieces.Empty)       // check left-up place is free
                        moves = addMove(moves, new Point(SelectedPlace.X - 1, SelectedPlace.Y - 1));
                    else if (opponent.Contains(Gameboard[SelectedPlace.X - 1, SelectedPlace.Y - 1]))       // check is left-up place is opponent
                    {
                        if (checkIsMoveOutOfBounds(SelectedPlace.X - 2, SelectedPlace.Y - 2) == false)      // check is left-up jump is out of bounds board
                        {
                            if (Gameboard[SelectedPlace.X - 2, SelectedPlace.Y - 2] == (int)Pieces.Empty)       //check is left-up place behind opponent is free
                                moves = addMove(moves, new Point(SelectedPlace.X - 2, SelectedPlace.Y - 2));
                        }
                    }
                }
                if (checkIsMoveOutOfBounds(SelectedPlace.X - 1, SelectedPlace.Y + 1) == false)        // check is right-up place is out of bounds board
                {
                    if (Gameboard[SelectedPlace.X - 1, SelectedPlace.Y + 1] == (int)Pieces.Empty)       // check is right-up place is free
                        moves = addMove(moves, new Point(SelectedPlace.X - 1, SelectedPlace.Y + 1));
                    else if (opponent.Contains(Gameboard[SelectedPlace.X - 1, SelectedPlace.Y + 1]))       // check is right-up place is opponent
                    {
                        if (checkIsMoveOutOfBounds(SelectedPlace.X - 2, SelectedPlace.Y + 2) == false)      // check is right-up jump is out of bounds board
                        {
                            if (Gameboard[SelectedPlace.X - 2, SelectedPlace.Y + 2] == (int)Pieces.Empty)       // check is right-up place behind opponent is free
                                moves = addMove(moves, new Point(SelectedPlace.X - 2, SelectedPlace.Y + 2));
                        }
                    }
                }
            }
            if (color == (int)Pieces.BlackPawn || king == true)     // check place for black piece or king
            {
                if (checkIsMoveOutOfBounds(SelectedPlace.X + 1, SelectedPlace.Y - 1) == false)      // check is left-down place is out of bounds board
                {
                    if (Gameboard[SelectedPlace.X + 1, SelectedPlace.Y - 1] == (int)Pieces.Empty)       // check left-down place is free
                        moves = addMove(moves, new Point(SelectedPlace.X + 1, SelectedPlace.Y - 1));
                    else if (opponent.Contains(Gameboard[SelectedPlace.X + 1, SelectedPlace.Y - 1]))       // check is left-down place is opponent
                    {
                        if (checkIsMoveOutOfBounds(SelectedPlace.X + 2, SelectedPlace.Y - 2) == false)      // check is left-down jump is out of bounds board
                        {
                            if (Gameboard[SelectedPlace.X + 2, SelectedPlace.Y - 2] == (int)Pieces.Empty)       // check is left-down place behind opponent is free
                                moves = addMove(moves, new Point(SelectedPlace.X + 2, SelectedPlace.Y - 2));
                        }
                    }
                }
                if (checkIsMoveOutOfBounds(SelectedPlace.X + 1, SelectedPlace.Y + 1) == false)       // check is right-down place is out of bounds board
                {
                    if (Gameboard[SelectedPlace.X + 1, SelectedPlace.Y + 1] == (int)Pieces.Empty)       // check right-down place is free
                        moves = addMove(moves, new Point(SelectedPlace.X + 1, SelectedPlace.Y + 1));
                    else if (opponent.Contains(Gameboard[SelectedPlace.X + 1, SelectedPlace.Y + 1]))      // check is right-down place is opponent
                    {
                        if (checkIsMoveOutOfBounds(SelectedPlace.X + 2, SelectedPlace.Y + 2) == false)      // check is right-down jump is out of bounds board
                        {
                            if (Gameboard[SelectedPlace.X + 2, SelectedPlace.Y + 2] == (int)Pieces.Empty)        // check is right-down place behind opponent is free
                                moves = addMove(moves, new Point(SelectedPlace.X + 2, SelectedPlace.Y + 2));
                        }
                    }
                }
            }
            return moves;
        }

        public object Clone() // for deep copy object
        {
            //Player playerWhite = new Player(PlayerWhite.Name, PlayerWhite.PlayerColors, PlayerWhite.PawnsLeft, PlayerWhite.KingsLeft);
            //Player playerBlack = new Player(PlayerBlack.Name, PlayerBlack.PlayerColors, PlayerBlack.PawnsLeft, PlayerBlack.KingsLeft);
            Player playerWhite = (Player)PlayerWhite.Clone();
            Player playerBlack = (Player)PlayerBlack.Clone();
            Board cloned = new Board(playerWhite, playerBlack);
            cloned.Gameboard = new int[8, 8];

            for (int i = 0; i < Gameboard.GetLength(0); i++)
            {
                for (int j = 0; j < Gameboard.GetLength(1); j++)
                {
                    cloned.Gameboard[i, j] = Gameboard[i, j];
                }
            }
            return cloned;
        }
    }
}

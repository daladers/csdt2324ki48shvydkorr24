using task3;
using task3.Classes;
using Microsoft.VisualBasic.Devices;
using System.Drawing;
using System.Net.NetworkInformation;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace task3
{
    public partial class CheckersForm : Form
    {
        private Board _board;
        private PictureBox[,] _places = new PictureBox[8, 8];
        private Point _selectedPieceLocation { get; set; }
        private Point[] _selectedMoves = new Point[4];
        private bool _isAITurn = false;

        public CheckersForm()
        {
            InitializeComponent();
            InitializeGameBoard(Setting.FirstMove);
            NewTurn();
        }

        private void InitializeGameBoard(bool FirstMove) // create and display board with piece
        {
            _board = new Board(FirstMove);

            int xLoc = 0, yLoc = 0;
            Color[] colors = new Color[] { Color.White, Color.Gray };
            int white = 0;

            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    _places[x, y] = new PictureBox();
                    _places[x, y].Location = new Point(xLoc, yLoc);
                    _places[x, y].BackColor = colors[white % 2];
                    _places[x, y].AccessibleDescription = "" + x.ToString() + "," + y.ToString();
                    _places[x, y].Size = new Size(75, 75);
                    mainBoard.Controls.Add(_places[x, y]);
                    xLoc += 75;
                    white++;
                    SetPiece(new Point(x, y));
                }
                white++;
                xLoc = 0;
                yLoc += 75;
            }
            PlayerWhiteNameLabel.Text = Setting.Player1Name;
            PlayerBlackNameLabel.Text = Setting.Player2Name;
        }

        private void UpdateBoardUI() // update gameboard
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (_board.IsWin == false)
                        SetPiece(new Point(x, y));
                    else
                        break;
                }
            }
        }

        private void UpdatePlayerUI() // update player text
        {
            PlayerBlackScoreLabel.Text = _board.PlayerBlack.Score.ToString();
            PlayerWhiteScoreLabel.Text = _board.PlayerWhite.Score.ToString();
            if (_board.IsWin == true)
            {
                PlayerWin();
            }
                
            else if (_board.IsWhiteTurn == true)
            {
                PlayerWhiteTurn.Visible = true;
                Player2Turn.Visible = false;
            }
            else
            {
                PlayerWhiteTurn.Visible = false;
                Player2Turn.Visible = true;
            }
        }

        private void PlayerWin() // show win message 
        {
            mainBoard.Enabled = false;
            string name;
            if (_board.PlayerBlack.Score == 12)
                name = _board.PlayerBlack.Name;
            else
                name = _board.PlayerWhite.Name;
            Player2Turn.Visible = false;
            PlayerWhiteTurn.Visible = false;
            MessageBox.Show(name + " is win!");
        }
        private void NewTurn()
        {
            UpdatePlayerUI();
            if (Setting.isAiPlay == false)     // for player vs player
            {
                if (_board.IsWhiteTurn)
                    _board.checkAllMoves(2);
                else
                    _board.checkAllMoves(1);
            }
            else    // for player vs computer
            {
                if (_board.IsWhiteTurn)
                    _board.checkAllMoves(2);
                else
                {
                    _isAITurn = true;
                    AITurn();
                    //_board.changePlayerTurn();
                    _isAITurn = false;
                    _board.checkAllMoves(2);
                    UpdatePlayerUI();
                }
            }
        }

        private void DisplayAvailableMovesForSelectedPiece() // display on board available moves for selected piece
        {
            if (_places[_selectedPieceLocation.X, _selectedPieceLocation.Y].BackColor == Color.Gray)
            {
                foreach (var move in _board.ListMoves)
                {
                    if (move[0] == _selectedPieceLocation)
                    {
                        _places[_selectedPieceLocation.X, _selectedPieceLocation.Y].BackColor = Color.DarkBlue;
                        _places[move[1].X, move[1].Y].AccessibleName = "green";
                        if (Setting.ShowMove == true)
                            _places[move[1].X, move[1].Y].BackColor = Color.Green;
                    }
                }
            }
        }

        private void MouseClickPlace(PictureBox selectedPlace) // function to check which piece was clicked
        {
            selectedPlace.MouseClick += (sender2, e2) => // check first click on board
            {
                if (_isAITurn == false)
                {
                    PictureBox piece = sender2 as PictureBox;
                    if (piece.Image != null)
                    {
                        int[] placeLocation = piece.AccessibleDescription.Split(',').Select(int.Parse).ToArray();
                        RemoveGreenPlaceFromBoard();
                        _selectedPieceLocation = new Point(placeLocation[0], placeLocation[1]);
                        DisplayAvailableMovesForSelectedPiece();
                    }
                }
            };

            selectedPlace.MouseClick += (sender3, e3) => // check second click on board
            {
                if (_isAITurn == false)
                {
                    PictureBox piece = sender3 as PictureBox;
                    if (selectedPlace.AccessibleName == "green" || selectedPlace.BackColor == Color.Green)
                    {
                        int[] placeLocation = piece.AccessibleDescription.Split(',').Select(int.Parse).ToArray();
                        Point GreenMove = new Point(placeLocation[0], placeLocation[1]);
                        MoveSelectedPiece(_selectedPieceLocation, GreenMove);
                        NewTurn();
                    }
                }
            };
        }   

        private void SetPiece(Point piece) // set piece on board
        {
            if (_board.Gameboard[piece.X, piece.Y] == 1) // set black piece
            {
                _places[piece.X, piece.Y].Image = Properties.Resources.blackPiece;
                _places[piece.X, piece.Y].Image.Tag = "black";
            }
            else if (_board.Gameboard[piece.X, piece.Y] == 2) // set white piece
            {
                _places[piece.X, piece.Y].Image = Properties.Resources.whitePiece;
                _places[piece.X, piece.Y].Image.Tag = "white";
            }
            else if (_board.Gameboard[piece.X, piece.Y] == 3) // set black king piece
            {
                _places[piece.X, piece.Y].Image = Properties.Resources.blackPieceKing;
                _places[piece.X, piece.Y].Image.Tag = "black";
            }
            else if (_board.Gameboard[piece.X, piece.Y] == 4) // set white king piece
            {
                _places[piece.X, piece.Y].Image = Properties.Resources.whitePieceKing;
                _places[piece.X, piece.Y].Image.Tag = "white";
            }
            else if (_places[piece.X, piece.Y].BackColor == Color.Green) // remove green place
            {
                _places[piece.X, piece.Y].BackColor = Color.Gray;
                _places[piece.X, piece.Y].AccessibleName = null;
            }
            else
            {
                _places[piece.X, piece.Y].Image = null; // clean place (remove piece)
            }
            _places[piece.X, piece.Y].SizeMode = PictureBoxSizeMode.CenterImage;
            UpdatePlayerUI();
        }

        private void MoveSelectedPiece(Point selectedPiece, Point move) // move selected piece on selected move place
        {
            _board.MakeMove(selectedPiece, move);
            UpdateBoardUI();
            RemoveGreenPlaceFromBoard();
        }

        private void RemoveGreenPlaceFromBoard() // remove available moves from board
        {
            foreach (Point[] move in _board.ListMoves)
            {
                for (int i = 0; i < move.Length; i++)
                {
                    _places[move[i].X, move[i].Y].BackColor = Color.Gray;
                    _places[move[i].X, move[i].Y].AccessibleName = null;
                }
            }
        }

        private void AITurn() // turn play by AI
        {
            MinMax AI = new MinMax(_board, 3);
            AI.Calculate();
            MoveSelectedPiece(AI.BestMove[0], AI.BestMove[1]);
        }

        private void UpdateGameBoard(object sender, EventArgs e) // scanning board to check if was click on place
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (_board.IsWin == false)
                        MouseClickPlace(_places[x, y]);
                    else
                        break;
                }
            }
        }
    }
}
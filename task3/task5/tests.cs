using System.Drawing;
using System.Runtime.CompilerServices;
using task3;
using task3.Classes;
using Microsoft.VisualBasic.Devices;

namespace task5
{
    public class tests
    {
        [Fact]
        public void Player_Win() // if player has 12 score then win
        {
            Board board = new Board(true);
            for (int i = 0; i < 12; i++)
                board.PlayerWhite.IncreaseScore();
            var player = board.PlayerWhite;
            var win = board.isPLayerWin(player);

            Assert.True(win);
        }
        [Fact]
        public void First_White_Turn() // defualt first move is white piece
        {
            Board board = new Board(true);

            var turn = board.IsWhiteTurn;

            Assert.True(turn);
        }
        [Fact]
        public void Add_Score() // check score after capture jump
        {
            int[,] tmpGameboard = new int[8, 8] {
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,1,0,1,0,0 },
                { 0,0,0,0,2,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 }
            };
            Board board = new Board(tmpGameboard, 1, 2, 0, 0);
            board.MakeMove(new Point(5, 4), new Point(3, 2));
            Assert.Equal(1, board.PlayerWhite.Score);
        }
        [Fact]
        public void White_Piece_Moves_Center() // In center, piece has 2 moves
        {
            int[,] tmpGameboard = new int[8, 8] {
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,2,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 }
            };
            Point[] centerPiece = { new Point(5, 4), new Point(4, 3) }; // Center Piece move
            Point[] centerPiece2 = { new Point(5, 4), new Point(4, 5) };
            List<Point[]> ListMoves = new List<Point[]>();
            ListMoves.Add(centerPiece);
            ListMoves.Add(centerPiece2);
            var board = new Board(tmpGameboard, 1, 0, 0, 0);
            board.checkAllMoves(2);

            Assert.Equal(ListMoves, board.ListMoves);
        }
        [Fact]
        public void White_Piece_Moves_Left() // In left, piece has 1 move
        {
            int[,] tmpGameboard = new int[8, 8] {
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 2,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 }
            };
            Point[] LeftPiece = { new Point(5, 0), new Point(4, 1) }; // Left Piece move

            List<Point[]> ListMoves = new List<Point[]>();
            ListMoves.Add(LeftPiece);

            var board = new Board(tmpGameboard, 1, 0, 0, 0);
            board.checkAllMoves(2);

            Assert.Equal(ListMoves, board.ListMoves);
        }
        [Fact]
        public void White_Piece_Moves_Right() // In right, piece has 1 move
        {
            int[,] tmpGameboard = new int[8, 8] {
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,2 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 }
            };
            Point[] rightPiece = { new Point(4, 7), new Point(3, 6) }; // Right Piece move

            List<Point[]> ListMoves = new List<Point[]>();
            ListMoves.Add(rightPiece);

            var board = new Board(tmpGameboard, 1, 0, 0, 0);
            board.checkAllMoves(2);

            Assert.Equal(ListMoves, board.ListMoves);
        }
        [Fact]
        public void White_Piece_Convert_To_King() // check is piece convert to king after move to up board line
        {
            int[,] tmpGameboard = new int[8, 8] {
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,2,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 }
            };

            var board = new Board(tmpGameboard, 1, 0, 0, 0);
            board.MakeMove(new Point(1, 6), new Point(0, 5));

            Assert.Equal(4, board.Gameboard[0, 5]);
        }
        [Fact]
        public void Piece_Capture() // White piece capture jump
        {
            int[,] tmpGameboard = new int[8, 8] {
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,1,0,1,0,0 },
                { 0,0,0,0,2,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 }
            };
            var board = new Board(tmpGameboard, 1, 2, 0, 0);
            board.MakeMove(new Point(5, 4), new Point(3, 2));

            Assert.Equal(0, board.Gameboard[4, 3]);
        }
    }
}


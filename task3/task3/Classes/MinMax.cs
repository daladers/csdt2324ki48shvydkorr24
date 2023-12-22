using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using task3.Classes;
using static System.Formats.Asn1.AsnWriter;

namespace task3.Classes
{
    public class MinMax
    {
        private Board _board;
        private int _depth;
        public Point[] BestMove;

        public MinMax(Board board, int depth)
        {
            _board = board;
            _depth = depth;
        }
        public void Calculate()
        {
            var result = MinMaxAlgorithm(_board, _depth, true);
            BestMove = result.Item2;
        }
        public Board DeserializeFromIni(string configdata)
        {
            // Split the configdata into sections
            string[] sections = configdata.Split(new[] { "[", "]" }, StringSplitOptions.RemoveEmptyEntries);

            // Initialize variables to store player and gameboard information
            string playerWhiteName = "", playerBlackName = "";
            int[] playerWhiteData = new int[4], playerBlackData = new int[4];
            int[,] gameboard = new int[8, 8];

            // Loop through sections and parse the data
            foreach (var section in sections)
            {
                var lines = section.Split('\n', StringSplitOptions.RemoveEmptyEntries);

                if (lines.Length > 1)
                {
                    // Process PlayerWhite section
                    if (lines[0].Trim() == "PlayerWhite")
                    {
                        playerWhiteData[0] = int.Parse(GetValue(lines, "PawnsLeft"));
                        playerWhiteData[1] = int.Parse(GetValue(lines, "KingsLeft"));
                        playerWhiteData[2] = int.Parse(GetValue(lines, "Score"));
                    }
                    // Process PlayerBlack section
                    else if (lines[0].Trim() == "PlayerBlack")
                    {
                        playerBlackData[0] = int.Parse(GetValue(lines, "PawnsLeft"));
                        playerBlackData[1] = int.Parse(GetValue(lines, "KingsLeft"));
                        playerBlackData[2] = int.Parse(GetValue(lines, "Score"));
                    }
                    // Process Gameboard section
                    else if (lines[0].Trim() == "Gameboard")
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                string cellKey = $"Cell_{i}_{j}";
                                gameboard[i, j] = int.Parse(GetValue(lines, cellKey));
                            }
                        }
                    }
                }
            }

            // Create and return a new Board instance
            Player playerWhite = new Player(playerWhiteName, new int[] { 2, 4 }, playerWhiteData[0], playerWhiteData[1]);
            Player playerBlack = new Player(playerBlackName, new int[] { 1, 3 }, playerBlackData[0], playerBlackData[1]);
            Board board = new Board(gameboard, playerWhiteData[0], playerBlackData[0], playerWhiteData[1], playerBlackData[1]);
            board.PlayerWhite = playerWhite;
            board.PlayerBlack = playerBlack;

            return board;
        }

        private string GetValue(string[] lines, string key)
        {
            foreach (var line in lines)
            {
                if (line.Contains(key))
                {
                    return line.Split('=')[1].Trim();
                }
            }
            return "";
        }

        public void SerializeToIni(Board board)
        {
            string iniFilePath = "D:\\lpnu\\4 курс\\7 семестр\\CSAD (Автоматизоване проектування комп`ютерних систем)\\labs\\csdt2324ki48shvydkorr24\\task3\\task3\\config\\config.ini";
            INIFile iniFile = new INIFile(iniFilePath);

            // Serialize PlayerWhite
            iniFile.Write("PlayerWhite", "PawnsLeft", board.PlayerWhite.PawnsLeft.ToString());
            iniFile.Write("PlayerWhite", "KingsLeft", board.PlayerWhite.KingsLeft.ToString());
            iniFile.Write("PlayerWhite", "Score", board.PlayerWhite.Score.ToString());

            // Serialize PlayerBlack
            iniFile.Write("PlayerBlack", "PawnsLeft", board.PlayerBlack.PawnsLeft.ToString());
            iniFile.Write("PlayerBlack", "KingsLeft", board.PlayerBlack.KingsLeft.ToString());
            iniFile.Write("PlayerBlack", "Score", board.PlayerBlack.Score.ToString());

            // Serialize Gameboard
            for (int i = 0; i < board.Gameboard.GetLength(0); i++)
            {
                for (int j = 0; j < board.Gameboard.GetLength(1); j++)
                {
                    iniFile.Write("Gameboard", $"Cell_{i}_{j}", board.Gameboard[i, j].ToString());
                }
            }
        }
        public string iniToString(Board board)
        {
            string iniFilePath = "D:\\lpnu\\4 курс\\7 семестр\\CSAD (Автоматизоване проектування комп`ютерних систем)\\labs\\csdt2324ki48shvydkorr24\\task3\\task3\\config\\config.ini";
            INIFile iniFile = new INIFile(iniFilePath);
            string configdata = "";
            configdata += iniFile.Read("PlayerWhite", "PawnsLeft") + ",";
            configdata += iniFile.Read("PlayerWhite", "KingsLeft") + ",";
            configdata += iniFile.Read("PlayerWhite", "Score") + ",";

            configdata += iniFile.Read("PlayerBlack", "PawnsLeft") + ",";
            configdata += iniFile.Read("PlayerBlack", "KingsLeft") + ",";
            configdata += iniFile.Read("PlayerBlack", "Score") + ",";

            for (int i = 0; i < board.Gameboard.GetLength(0); i++)
            {
                for (int j = 0; j < board.Gameboard.GetLength(1); j++)
                {
                    configdata += iniFile.Read("Gameboard", $"Cell_{i}_{j}") + ",";
                }
            }
            return configdata;
        }
        public (int, Point[]) MinMaxAlgorithm(Board board, int depth, bool maxPlayer)
        {
            //SerialPort serialPort = new SerialPort("COM1", 9600);
            //serialPort.Open();
            if (depth == 0 || board.IsWin == true)
            {
                Point[] points = new Point[2];
                return (EvaluateMove(board), points);
            }
            if (maxPlayer == true) // simulation computer turn
            {
                int maxValue = int.MinValue;
                Point[] Best = new Point[2];
                board.checkAllMoves(1);

                SerialPort serialPort = new SerialPort("COM1", 9600);
                string receivedData = "";
                foreach (var move in board.ListMoves)
                {
                    //SerialPort serialPort = new SerialPort("COM1", 9600);
                    //string receivedData = "";
                    Board child = (Board)board.Clone();
                    child.MakeMove(move[0], move[1]);
                    try
                    {
                        serialPort.Open();
                        SerializeToIni(child);
                        string configdata = iniToString(child);
                        serialPort.Write(configdata);
                        receivedData = serialPort.ReadExisting();
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        Console.WriteLine("Помилка доступу до порту: " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Інша помилка при роботі з портом: " + ex.Message);
                    }
                    finally
                    {
                        if (serialPort.IsOpen)
                        {
                            serialPort.Close();
                        }
                    }
                    Board child2 = DeserializeFromIni(receivedData);
                    var result = MinMaxAlgorithm(child2, depth - 1, false);
                    maxValue = Math.Max(maxValue, result.Item1);
                    if (result.Item1 <= maxValue)
                    {
                        Best[0] = move[0];
                        Best[1] = move[1];
                    }
                }
                return (maxValue, Best);
            }
            else // simulation player turn
            {
                int minValue = int.MaxValue;
                Point[] Best = new Point[2];
                board.checkAllMoves(2);
                foreach (var move in board.ListMoves)
                {
                    Board child = (Board)board.Clone();
                    child.MakeMove(move[0], move[1]);
                    var result = MinMaxAlgorithm(child, depth - 1, true);
                    minValue = Math.Min(minValue, result.Item1);
                    if (result.Item1 >= minValue)
                    {
                        Best[0] = move[0];
                        Best[1] = move[1];
                    }
                }
                return (minValue, Best);
            }
        }
        /*
        Evaluation function for MinMax algorithm
        Pawn value = 1
        King value = 2
        Board position value = [1-4]
        Player pawns == 0 => Win
        Computer pawns == 0 => Lose
        */
        public int EvaluateMove(Board board)
        {
            int win = int.MaxValue / 2;
            int lose = int.MinValue / 2;
            int[] opponent = new int[2] { 1, 3 };
            int[,] boardValue = new int[8, 8] {
                { 0,4,0,4,0,4,0,4 },
                { 4,0,3,0,3,0,3,0 },
                { 0,3,0,2,0,2,0,4 },
                { 4,0,2,0,1,0,3,0 },
                { 0,3,0,1,0,2,0,4 },
                { 4,0,2,0,2,0,3,0 },
                { 0,3,0,3,0,3,0,4 },
                { 4,0,4,0,4,0,4,0 }
            };
            int scorePlayer = 0, scoreComputer = 0;
            for(int i = 0; i < 8; i++)
            {
                for (int j = 0;j<8; j++)
                {
                    if (board.Gameboard[i, j] != 0)
                    {
                        if (opponent.Contains(board.Gameboard[i, j]))
                            scoreComputer += boardValue[i, j];
                        else
                            scorePlayer += boardValue[i, j];
                    }
                }
            }
            if (board.PlayerBlack.PawnsLeft == 0)
                return lose;
            if (board.PlayerWhite.PawnsLeft == 0)
                return win;
            int pawns = board.PlayerBlack.PawnsLeft - board.PlayerWhite.PawnsLeft;
            int kings = board.PlayerBlack.KingsLeft * 2 - board.PlayerWhite.KingsLeft * 2;
            int score = scoreComputer - scorePlayer;
            return pawns + kings + score;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3.Classes
{
    public class Player : ICloneable
    {
        public string Name { get; private set; }
        public int Score { get; private set; }
        public int PawnsLeft { get; private set; }
        public int KingsLeft { get; private set; }
        public int[] PlayerColors { get; private set; }
        public Player(string name, int[] playerColors)
        {
            Name = name;
            PlayerColors = playerColors;
            Score = 0;
            PawnsLeft = 12;
            KingsLeft = 0;
        }
        public Player(string name, int[] playerColors, int pawnsLeft, int kingsLeft)
        {
            Name = name;
            PlayerColors = playerColors;
            Score = 0;
            PawnsLeft = 12;
            KingsLeft = 0;
        }
        public Player()
        {

        }
        public void CapturePawns()
        {
            PawnsLeft -= 1;
        }
        public void AddKing()
        {
            PawnsLeft -= 1;
            KingsLeft += 1;
        }
        public void CaptureKing()
        {
            KingsLeft -= 1;
        }
        public void IncreaseScore()
        {
            Score += 1;
        }

        public object Clone()
        {
            Player cloned = new Player();
            cloned.PawnsLeft = PawnsLeft;
            cloned.KingsLeft = KingsLeft;
            cloned.PlayerColors = PlayerColors;
            cloned.Score = Score;
            return cloned;
        }
    }
}

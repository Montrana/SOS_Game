using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS_Game
{
    internal class Player
    {
        public int Score { get; private set; }
        public bool IsTurn {  get; private set; }

        public Player() {
            Score = 0;
            IsTurn = false;
        }
        public void AddScore(int score)
        {
            Score += score;
        }
        public void NewGame()
        {
            Score = 0;
        }
        public void UpdateTurn()
        {
            if (IsTurn)
            {
                IsTurn = false;
            }
            else
            {
                IsTurn = true;
            }
        }
    }
}

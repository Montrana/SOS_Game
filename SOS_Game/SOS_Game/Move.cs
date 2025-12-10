using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS_Game
{
    internal class Move
    {
        public GameScreen.CellIndex Coordinate { get; protected set; }
        public Player Player { get; protected set; }
        public string Letter { get; protected set; }
        public Move(GameScreen.CellIndex coordinate, Player player, string letter)
        {
            Coordinate = coordinate;
            Player = player;
            Letter = letter;
        }
    }
}

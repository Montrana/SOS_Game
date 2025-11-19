using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS_Game
{
    internal class Game
    {
        public enum GameType
        {
            simple,
            complex
        }
        public GameType Game_Type { get; private set; }
        public int GridSize { get; private set; }

        public Game(int gridSize, GameType gameType)
        {
            GridSize = gridSize;
            Game_Type = gameType;
        }

        public Game(int gridSize)
        {
            Game_Type = GameType.simple;
            GridSize = gridSize;
        }
    }
}

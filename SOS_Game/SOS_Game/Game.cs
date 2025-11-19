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

        public Game(GameType gameType)
        {
            Game_Type = gameType;
        }

        public Game()
        {
            Game_Type = GameType.simple;
        }
    }
}

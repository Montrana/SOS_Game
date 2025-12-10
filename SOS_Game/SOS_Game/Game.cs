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
        public bool isWinner {  get; private set; }
        public Player winner { get; private set; }

        public Game(GameType gameType)
        {
            isWinner = false;
            Game_Type = gameType;
        }

        public Game()
        {
            isWinner = false;
            Game_Type = GameType.simple;
        }
        public void DeclareWinner(Player player)
        {
            isWinner = true;
            winner = player;
        }
    }
}

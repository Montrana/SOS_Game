using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SOS_Game.GameScreen;

namespace SOS_Game
{
    internal class Player
    {
        public int Score { get; protected set; }
        public bool IsTurn { get; protected set; }
        public bool IsHuman { get; protected set; }
        public Color PlayerColor { get; protected set; }
        public string PlayerName { get; protected set; }
        

        public Player(Color color)
        {
            Score = 0;
            IsTurn = false;
            PlayerColor = color;
            PlayerName = color.Name;
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


        public int PlaceS_CheckSOS(TableLayoutPanel gameGrid, GameScreen.CellIndex cellIndex)
        {
            int SOSCreations = 0;
            // Vertical Checks
            Control tempS;
            Control tempO;
            GameScreen screen = new GameScreen();
            int gridSize = gameGrid.RowCount;
            if (cellIndex.y + 2 < gridSize)
            {
                tempS = gameGrid.GetControlFromPosition(cellIndex.x, cellIndex.y + 2);
                tempO = gameGrid.GetControlFromPosition(cellIndex.x, cellIndex.y + 1);
                if (tempS.Text == "S" && tempO.Text == "O")
                {
                    using (Graphics g = gameGrid.CreateGraphics())
                    {
                        screen.DrawLineSOS(g, gameGrid, cellIndex.x, cellIndex.x, cellIndex.x,
                            cellIndex.y, cellIndex.y + 1, cellIndex.y + 2, PlayerColor);
                    }
                    SOSCreations++;
                }
            }
            if (cellIndex.y - 2 >= 0)
            {
                tempS = gameGrid.GetControlFromPosition(cellIndex.x, cellIndex.y - 2);
                tempO = gameGrid.GetControlFromPosition(cellIndex.x, cellIndex.y - 1);
                if (tempS.Text == "S" && tempO.Text == "O")
                {
                    using (Graphics g = gameGrid.CreateGraphics())
                    {
                        screen.DrawLineSOS(g, gameGrid, cellIndex.x, cellIndex.x, cellIndex.x,
                            cellIndex.y - 2, cellIndex.y - 1, cellIndex.y, PlayerColor);
                    }
                    SOSCreations++;
                }
            }

            // Horizontal Checks
            if (cellIndex.x + 2 < gridSize)
            {
                tempS = gameGrid.GetControlFromPosition(cellIndex.x + 2, cellIndex.y);
                tempO = gameGrid.GetControlFromPosition(cellIndex.x + 1, cellIndex.y);
                if (tempS.Text == "S" && tempO.Text == "O")
                {
                    using (Graphics g = gameGrid.CreateGraphics())
                    {
                        screen.DrawLineSOS(g, gameGrid, cellIndex.x, cellIndex.x + 1, cellIndex.x + 2,
                            cellIndex.y, cellIndex.y, cellIndex.y, PlayerColor);
                    }
                    SOSCreations++;
                }
            }

            if (cellIndex.x - 2 >= 0)
            {
                tempS = gameGrid.GetControlFromPosition(cellIndex.x - 2, cellIndex.y);
                tempO = gameGrid.GetControlFromPosition(cellIndex.x - 1, cellIndex.y);
                if (tempS.Text == "S" && tempO.Text == "O")
                {
                    using (Graphics g = gameGrid.CreateGraphics())
                    {
                        screen.DrawLineSOS(g, gameGrid, cellIndex.x - 2, cellIndex.x - 1, cellIndex.x,
                            cellIndex.y, cellIndex.y, cellIndex.y, PlayerColor);
                    }
                    SOSCreations++;
                }
            }

            // Diagonal Checks
            if (cellIndex.y + 2 < gridSize && cellIndex.x + 2 < gridSize)
            {
                tempS = gameGrid.GetControlFromPosition(cellIndex.x + 2, cellIndex.y + 2);
                tempO = gameGrid.GetControlFromPosition(cellIndex.x + 1, cellIndex.y + 1);
                if (tempS.Text == "S" && tempO.Text == "O")
                {
                    using (Graphics g = gameGrid.CreateGraphics())
                    {
                        screen.DrawLineSOS(g, gameGrid, cellIndex.x, cellIndex.x + 1, cellIndex.x + 2,
                            cellIndex.y, cellIndex.y + 1, cellIndex.y + 2, PlayerColor);
                    }
                    SOSCreations++;
                }
            }
            if (cellIndex.y + 2 < gridSize && cellIndex.x - 2 >= 0)
            {
                tempS = gameGrid.GetControlFromPosition(cellIndex.x - 2, cellIndex.y + 2);
                tempO = gameGrid.GetControlFromPosition(cellIndex.x - 1, cellIndex.y + 1);
                if (tempS.Text == "S" && tempO.Text == "O")
                {
                    using (Graphics g = gameGrid.CreateGraphics())
                    {
                        screen.DrawLineSOS(g, gameGrid, cellIndex.x - 2, cellIndex.x - 1, cellIndex.x,
                            cellIndex.y, cellIndex.y + 1, cellIndex.y + 2, PlayerColor);
                    }
                    SOSCreations++;
                }
            }
            if (cellIndex.y - 2 >= 0 && cellIndex.x + 2 < gridSize)
            {
                tempS = gameGrid.GetControlFromPosition(cellIndex.x + 2, cellIndex.y - 2);
                tempO = gameGrid.GetControlFromPosition(cellIndex.x + 1, cellIndex.y - 1);
                if (tempS.Text == "S" && tempO.Text == "O")
                {
                    using (Graphics g = gameGrid.CreateGraphics())
                    {
                        screen.DrawLineSOS(g, gameGrid, cellIndex.x, cellIndex.x + 1, cellIndex.x + 2,
                            cellIndex.y, cellIndex.y, cellIndex.y, PlayerColor);
                    }
                    SOSCreations++;
                }
            }
            if (cellIndex.y - 2 >= 0 && cellIndex.x - 2 >= 0)
            {
                tempS = gameGrid.GetControlFromPosition(cellIndex.x - 2, cellIndex.y - 2);
                tempO = gameGrid.GetControlFromPosition(cellIndex.x - 1, cellIndex.y - 1);
                if (tempS.Text == "S" && tempO.Text == "O")
                {
                    using (Graphics g = gameGrid.CreateGraphics())
                    {
                        screen.DrawLineSOS(g, gameGrid, cellIndex.x - 2, cellIndex.x - 1, cellIndex.x,
                            cellIndex.y - 2, cellIndex.y - 1, cellIndex.y, PlayerColor);
                    }
                    SOSCreations++;
                }
            }
            return SOSCreations;
        }
        public int PlaceO_CheckSOS(TableLayoutPanel gameGrid, GameScreen.CellIndex cellIndex)
        {
            int SOSCreations = 0;
            Control tempS1;
            Control tempS2;
            GameScreen screen = new GameScreen();
            int gridSize = gameGrid.RowCount;

            // Vertical Checks
            if (cellIndex.y + 1 < gridSize && cellIndex.y - 1 >= 0)
            {
                tempS1 = gameGrid.GetControlFromPosition(cellIndex.x, cellIndex.y + 1);
                tempS2 = gameGrid.GetControlFromPosition(cellIndex.x, cellIndex.y - 1);
                if (tempS1.Text == "S" && tempS2.Text == "S")
                {
                    using (Graphics g = gameGrid.CreateGraphics())
                    {
                        screen.DrawLineSOS(g, gameGrid, cellIndex.x, cellIndex.x, cellIndex.x,
                            cellIndex.y - 1, cellIndex.y, cellIndex.y + 1, PlayerColor);
                    }
                    SOSCreations++;
                }
            }


            // Horizontal Checks
            if (cellIndex.x + 1 < gridSize && cellIndex.x - 1 >= 0)
            {
                tempS1 = gameGrid.GetControlFromPosition(cellIndex.x + 1, cellIndex.y);
                tempS2 = gameGrid.GetControlFromPosition(cellIndex.x - 1, cellIndex.y);
                if (tempS1.Text == "S" && tempS2.Text == "S")
                {
                    using (Graphics g = gameGrid.CreateGraphics())
                    {
                        screen.DrawLineSOS(g, gameGrid, cellIndex.x - 1, cellIndex.x, cellIndex.x + 1,
                            cellIndex.y, cellIndex.y, cellIndex.y, PlayerColor);
                    }
                    SOSCreations++;
                }
            }


            // Diagonal Checks
            if (cellIndex.y + 1 < gridSize && cellIndex.y - 1 >= 0
                && cellIndex.x + 1 < gridSize && cellIndex.x - 1 >= 0)
            {
                tempS1 = gameGrid.GetControlFromPosition(cellIndex.x + 1, cellIndex.y + 1);
                tempS2 = gameGrid.GetControlFromPosition(cellIndex.x - 1, cellIndex.y - 1);
                if (tempS1.Text == "S" && tempS2.Text == "S")
                {
                    using (Graphics g = gameGrid.CreateGraphics())
                    {
                        screen.DrawLineSOS(g, gameGrid, cellIndex.x - 1, cellIndex.x, cellIndex.x + 1,
                            cellIndex.y - 1, cellIndex.y, cellIndex.y + 1, PlayerColor);
                    }
                    SOSCreations++;
                }
                tempS1 = gameGrid.GetControlFromPosition(cellIndex.x + 1, cellIndex.y - 1);
                tempS2 = gameGrid.GetControlFromPosition(cellIndex.x - 1, cellIndex.y + 1);
                if (tempS1.Text == "S" && tempS2.Text == "S")
                {
                    using (Graphics g = gameGrid.CreateGraphics())
                    {
                        screen.DrawLineSOS(g, gameGrid, cellIndex.x - 1, cellIndex.x, cellIndex.x + 1,
                            cellIndex.y + 1, cellIndex.y, cellIndex.y - 1, PlayerColor);
                    }
                    SOSCreations++;
                }
            }
            return SOSCreations;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SOS_Game.GameScreen;

namespace SOS_Game
{
    internal static class Program
    {
        public enum GameType
        {
            simple,
            complex
        }
        public static Player red = new Player();
        public static Player blue = new Player();
        public static int gridSize;
        public static GameType gameType;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GameScreen());
        }
        public static int PlaceS_CheckSOS(TableLayoutPanel gameGrid, GameScreen.CellIndex cellIndex, Color color)
        {
            int SOSCreations = 0;
            // Vertical Checks
            Control tempS;
            Control tempO;
            GameScreen screen = new GameScreen();
            if (cellIndex.y + 2 < gridSize)
            {
                tempS = gameGrid.GetControlFromPosition(cellIndex.x, cellIndex.y + 2);
                tempO = gameGrid.GetControlFromPosition(cellIndex.x, cellIndex.y + 1);
                if (tempS.Text == "S" && tempO.Text == "O")
                {
                    using (Graphics g = gameGrid.CreateGraphics())
                    {
                        screen.DrawLineSOS(g, gameGrid, cellIndex.x, cellIndex.x, cellIndex.x,
                            cellIndex.y, cellIndex.y + 1, cellIndex.y + 2, color);
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
                            cellIndex.y - 2, cellIndex.y - 1, cellIndex.y, color);
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
                            cellIndex.y, cellIndex.y, cellIndex.y, color);
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
                            cellIndex.y, cellIndex.y, cellIndex.y, color);
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
                            cellIndex.y, cellIndex.y + 1, cellIndex.y + 2, color);
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
                            cellIndex.y, cellIndex.y + 1, cellIndex.y + 2, color);
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
                            cellIndex.y, cellIndex.y, cellIndex.y, color);
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
                            cellIndex.y - 2, cellIndex.y - 1, cellIndex.y, color);
                    }
                    SOSCreations++;
                }
            }
            return SOSCreations;
        }
        public static int PlaceO_CheckSOS(TableLayoutPanel gameGrid, GameScreen.CellIndex cellIndex, Color color)
        {
            int SOSCreations = 0;
            Control tempS1;
            Control tempS2;
            GameScreen screen = new GameScreen();

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
                            cellIndex.y - 1, cellIndex.y, cellIndex.y + 1, color);
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
                            cellIndex.y, cellIndex.y, cellIndex.y, color);
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
                            cellIndex.y - 1, cellIndex.y, cellIndex.y + 1, color);
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
                            cellIndex.y + 1, cellIndex.y, cellIndex.y - 1, color);
                    }
                    SOSCreations++;
                }
            }
            return SOSCreations;
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace SOS_Game
{
    public partial class GameScreen : Form
    {
        Random rand = new Random();
        private System.Windows.Forms.Timer timer;

        public struct CellIndex
        {
            public int x; public int y;
        }

        public GameScreen()
        {
            InitializeComponent();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 10;
            timer.Tick += Timer_Tick;
        }

        /// <summary>
        /// Continuous timer loop so that the AI continues making moves.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            foreach (Player player in Program.players)
            {
                if(player.IsTurn)
                {
                    if(player.IsHuman)
                    {
                        timer.Stop();
                    }
                    else if (!player.IsHuman)
                    {
                        Thread.Sleep(2500);
                        ComputerPlayer computer = (ComputerPlayer)player;
                        if (computer.ComputerMoveSelection(gameGrid))
                        {
                            if(Program.game.Game_Type == Game.GameType.simple)
                            {
                                WinnerLabel.Visible = true;
                                WinnerLabel.ForeColor = computer.PlayerColor;
                                timer.Stop();
                            }
                        }
                        else
                        {
                            UpdateTurn();
                        }
                    }
                    checkGridFull();
                    break;
                }
            }
        }

        /// <summary>
        /// Sets the text of the cell that gets clicked to S or O, with the color of the participant's turn.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameGrid_Click(object sender, EventArgs e)
        {
            var cellPos = GetRowColIndex(gameGrid, gameGrid.PointToClient(Cursor.Position)); // Determines the position of the cell being clicked
            CellIndex cellIndex;
            cellIndex.x = cellPos.Value.X;
            cellIndex.y = cellPos.Value.Y;
            Control cell = gameGrid.GetControlFromPosition(cellPos.Value.X, cellPos.Value.Y); // Sets control of the cell

            if(cell.Text == "") // Making sure the cell clicked is empty
            {
                foreach (Player player in Program.players)
                {
                    if (player.IsTurn & player.IsHuman)
                    {
                        HumanPlayer human = (HumanPlayer)player;
                        if (human.HumanMoveSelection(cell, gameGrid, cellIndex))
                        {
                            if(Program.game.Game_Type == Game.GameType.simple)
                            {
                                WinnerLabel.Visible = true;
                                WinnerLabel.ForeColor = human.PlayerColor;
                                timer.Stop();
                            }
                        }
                        else
                        {
                            UpdateTurn();
                            timer.Start();
                            break;
                        }
                    }
                    checkGridFull();
                }
            }
        }

        private void GameGrid_CellPaint(object sender, PaintEventArgs e)
        {

        }

        private void GridSizeNum_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
        
        /// <summary>
        /// Activates when the start button is clicked, starts the game process.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartButton_Click(object sender, EventArgs e)
        {
            if (blueS.Checked)
            {
                HumanPlayer blueHuman = new HumanPlayer(Color.Blue, blueS, blueO);
                Program.players[0] = blueHuman;
            }
            else if (blueO.Checked)
            {
                ComputerPlayer blueComputer = new ComputerPlayer(Color.Blue);
                Program.players[0] = blueComputer;
            }
            if (redS.Checked)
            {
                HumanPlayer redHuman = new HumanPlayer(Color.Red, redS, redO);
                Program.players[1] = redHuman;
                
            }
            else if (redO.Checked)
            {
                ComputerPlayer redComputer = new ComputerPlayer(Color.Red);
                Program.players[1] = redComputer;
            }
            Program.players[rand.Next(2)].UpdateTurn();

            const int defaultSize = 3;
            int gridSize;
            try
            {
                gridSize = int.Parse(gridSizeNum.Text);
            }
            catch
            {
                gridSize = defaultSize;
            }
            if (gridSize < 3 || gridSize > 10)
            {
                gridSize = defaultSize;
            }

            if (simpleButton.Checked)
            {
                Program.game = new Game();
            }
            else
            {
                Program.game = new Game(Game.GameType.complex);
            }
            blueS.Text = "S";
            blueO.Text = "O";
            redS.Text = "S";
            redO.Text = "O";
            CreateGrid(gridSize);
            UpdateTurn();
            timer.Start();
        }

        private void GridSizeLabel_Click(object sender, EventArgs e)
        {
            
        }

        private void GridBoxLabel_Click(object sender, EventArgs e)
        {
            GameGrid_Click(sender, e);
        }

        /// <summary>
        /// https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.radiobutton?view=windowsdesktop-9.0&redirectedfrom=MSDN
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RedS_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            if (rb == null)
            {
                MessageBox.Show("Sender is not a RadioButton");
                return;
            }
        }
        private void RedO_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            if (rb == null)
            {
                MessageBox.Show("Sender is not a RadioButton");
                return;
            }
        }
        private void BlueS_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            if (rb == null)
            {
                MessageBox.Show("Sender is not a RadioButton");
                return;
            }
        }
        private void BlueO_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            if (rb == null)
            {
                MessageBox.Show("Sender is not a RadioButton");
                return;
            }
        }
        private void SimpleButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
        }
        private void ComplexButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }
        private void turnLabel_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <param name="x3"></param>
        /// <param name="y1"></param>
        /// <param name="y2"></param>
        /// <param name="y3"></param>
        /// <param name="color"></param>
        public void DrawLineSOS(Graphics g, TableLayoutPanel gameGrid,
            int x1, int x2, int x3,
            int y1, int y2, int y3, Color color)
        {
            var offset = gameGrid.Location;
            Point point1 = GetCellCenterPoint(gameGrid, x1, y1);
            Point point2 = GetCellCenterPoint(gameGrid, x2, y2);
            Point point3 = GetCellCenterPoint(gameGrid, x3, y3);

            point1.X += offset.X;
            point1.Y += offset.Y;
            point2.X += offset.X;
            point2.Y += offset.Y;
            point3.X += offset.X;
            point3.Y += offset.Y;

            using (Pen pen = new Pen(color, 16))
            {
                g.DrawLine(pen, point1, point2);
                g.DrawLine(pen, point2, point3);
            }
        }

        Point GetCellCenterPoint(TableLayoutPanel gameGrid, int column, int row)
        {
            int[] widths = gameGrid.GetColumnWidths();
            int[] heights = gameGrid.GetRowHeights();

            int cellX = 0;
            for (int i = 0; i < column; i++)
            {
                cellX += widths[i];
            }

            int cellY = 0;
            for (int i = 0; i < row; i++)
            {
                cellY += heights[i];
            }

            int cellWidth = widths[column];
            int cellHeight = heights[row];

            int centerX = cellX + (cellWidth / 2);
            int centerY = cellY + (cellHeight / 2);

            return new Point(centerX, centerY);
        }

        /// <summary>
        /// Source: https://stackoverflow.com/questions/15449504/how-do-i-determine-the-cell-being-clicked-on-in-a-tablelayoutpanel
        /// </summary>
        /// <param name="gameGrid"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        Point? GetRowColIndex(TableLayoutPanel gameGrid, Point point)
        {
            if (point.X > gameGrid.Width || point.Y > gameGrid.Height)
                return null;

            int w = gameGrid.Width;
            int h = gameGrid.Height;
            int[] widths = gameGrid.GetColumnWidths();

            int i;
            for (i = widths.Length - 1; i >= 0 && point.X < w; i--)
                w -= widths[i];
            int col = i + 1;

            int[] heights = gameGrid.GetRowHeights();
            for (i = heights.Length - 1; i >= 0 && point.Y < h; i--)
                h -= heights[i];

            int row = i + 1;

            return new Point(col, row);
        }

        /// <summary>
        /// Update the turn from red to blue and vice versa
        /// </summary>
        private void UpdateTurn()
        {
            foreach(Player player in Program.players)
            {
                player.UpdateTurn();
                if (player.IsTurn)
                {
                    UpdateTurnLabel(player);
                    
                }
            }
        }
        private void UpdateTurnLabel(Player player)
        {
            turnLabel.Text = player.PlayerName + "'s Turn";
            turnLabel.ForeColor = player.PlayerColor;
        }

        /// <summary>
        /// Checks if the grid is full
        /// </summary>
        /// <returns></returns>
        private bool GridFull()
        {
            for (int x = 0; x < gameGrid.RowCount; x++)
            {
                for (int y = 0; y < gameGrid.RowCount; y++)
                {
                    Control cell = gameGrid.GetControlFromPosition(x, y);
                    if (cell.Text == "")
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void checkGridFull()
        {

            if (GridFull())
            {
                if (Program.players[0].Score > Program.players[1].Score)
                {
                    WinnerLabel.Visible = true;
                    WinnerLabel.ForeColor = Program.players[0].PlayerColor;
                }
                else if (Program.players[0].Score < Program.players[1].Score)
                {
                    WinnerLabel.Visible = true;
                    WinnerLabel.ForeColor = Program.players[1].PlayerColor;
                }
                else
                {
                    WinnerLabel.Visible = true;
                    WinnerLabel.Text = "Draw";
                }
                timer.Stop();
            }
        }

        private void gameGrid_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}

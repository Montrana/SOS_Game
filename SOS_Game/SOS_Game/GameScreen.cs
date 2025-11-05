using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace SOS_Game
{
    public partial class GameScreen : Form
    {
        RadioButton redSelected;
        RadioButton blueSelected;
        RadioButton gameSelected;
        Random rand = new Random();

        public struct CellIndex
        {
            public int x; public int y;
        }

        public GameScreen()
        {
            InitializeComponent();
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
                if (Program.red.IsTurn)
                {
                    if(redSelected != null)
                    {
                        cell.Text = redSelected.Text;
                        cell.ForeColor = Color.Red;
                    }
                    else
                    {
                        cell.Text = "S";
                        cell.ForeColor = Color.Red;
                    }
                    int addScore = 0;
                    if (cell.Text == "S")
                    {
                        addScore = Program.PlaceS_CheckSOS(gameGrid, cellIndex);
                        
                    }
                    else if (cell.Text == "O")
                    {
                        addScore = Program.PlaceO_CheckSOS(gameGrid, cellIndex);
                    }
                    if (addScore > 0)
                    {
                        Program.red.AddScore(addScore);
                        if (Program.gameType == Program.GameType.simple)
                        {
                            WinnerLabel.Visible = true;
                            WinnerLabel.ForeColor = Color.Red;
                        }
                    }
                    else
                    {
                        UpdateTurn();
                    }
                }
                else if (Program.blue.IsTurn)
                {
                    if (blueSelected != null)
                    {
                        cell.Text = blueSelected.Text;
                        cell.ForeColor = Color.Blue;
                    }
                    else
                    {
                        cell.Text = "S";
                        cell.ForeColor = Color.Blue;
                    }
                    int addScore = 0;
                    if (cell.Text == "S")
                    {
                        addScore = Program.PlaceS_CheckSOS(gameGrid, cellIndex);
                    }
                    else if (cell.Text == "O")
                    {
                        addScore = Program.PlaceO_CheckSOS(gameGrid, cellIndex);
                    }
                    if (addScore > 0)
                    {
                        Program.blue.AddScore(addScore);
                        if (Program.gameType == Program.GameType.simple)
                        {
                            WinnerLabel.Visible = true;
                            WinnerLabel.ForeColor = Color.Blue;
                        }
                    }
                    else
                    {
                        UpdateTurn();
                    }
                }
            }
            if (Program.gameType == Program.GameType.complex && CheckGridFull())
            {
                if (Program.red.Score > Program.blue.Score)
                {
                    WinnerLabel.Visible = true;
                    WinnerLabel.ForeColor = Color.Red;
                }
                else if (Program.red.Score < Program.blue.Score)
                {
                    WinnerLabel.Visible = true;
                    WinnerLabel.ForeColor = Color.Blue;
                }
                else
                {
                    WinnerLabel.Visible = true;
                    WinnerLabel.Text = "Draw";
                }
            }
        }

        private void GameGrid_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GridSizeNum_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
        
        private void StartButton_Click(object sender, EventArgs e)
        {
            if (rand.Next(1) == 0)
            {
                Program.red.UpdateTurn();
            }
            else
            {
                Program.blue.UpdateTurn();
            }
            if (gameSelected != null)
            {
                if (gameSelected.Text == "Simple Game")
                {
                    Program.gameType = Program.GameType.simple;
                }
                else
                {
                    Program.gameType = Program.GameType.complex;
                }
            }
            else
            {
                Program.gameType = Program.GameType.simple;
            }
            CreateGrid();
            UpdateTurn();
        }

        private void GridSizeLabel_Click(object sender, EventArgs e)
        {
            
        }

        private void GridBoxLabel_Click(object sender, EventArgs e)
        {
            GameGrid_Click(sender, e);
        }

        /// <summary>
        /// 
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

            // Ensure that the RadioButton.Checked property
            // changed to true.
            if (rb.Checked)
            {
                // Keep track of the selected RadioButton by saving a reference
                // to it.
                redSelected = rb;
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

            // Ensure that the RadioButton.Checked property
            // changed to true.
            if (rb.Checked)
            {
                // Keep track of the selected RadioButton by saving a reference
                // to it.
                redSelected = rb;
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

            // Ensure that the RadioButton.Checked property
            // changed to true.
            if (rb.Checked)
            {
                // Keep track of the selected RadioButton by saving a reference
                // to it.
                blueSelected = rb;
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

            // Ensure that the RadioButton.Checked property
            // changed to true.
            if (rb.Checked)
            {
                // Keep track of the selected RadioButton by saving a reference
                // to it.
                blueSelected = rb;
            }
        }
        private void SimpleButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            gameSelected = rb;
        }
        private void ComplexButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            gameSelected = rb;
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }
        private void turnLabel_Click(object sender, EventArgs e)
        {

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
            Program.red.UpdateTurn();
            Program.blue.UpdateTurn();
            if (Program.red.IsTurn)
            {
                turnLabel.Text = "Red's Turn";
                turnLabel.ForeColor = Color.Red;
            }
            else if(Program.blue.IsTurn)
            {
                turnLabel.Text = "Blue's Turn";
                turnLabel.ForeColor = Color.Blue;
            }
        }
        private bool CheckGridFull()
        {
            for (int x = 0; x < Program.gridSize; x++)
            {
                for (int y = 0; y < Program.gridSize; y++)
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
    }
}

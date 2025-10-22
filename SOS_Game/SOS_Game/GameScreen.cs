using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SOS_Game;

namespace SOS_Game
{
    public partial class GameScreen : Form
    {
        SOS_Game.Program.Turn turn = Program.Turn.Red;
        RadioButton redSelected;
        RadioButton blueSelected;

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
            Control cell = gameGrid.GetControlFromPosition(cellPos.Value.X, cellPos.Value.Y); // Sets control of the cell
            if(cell.Text == "") // Making sure the cell clicked is empty
            {
                if (turn == Program.Turn.Red)
                {
                    cell.Text = redSelected.Text;
                    cell.ForeColor = Color.Red;
                }
                else if (turn == Program.Turn.Blue)
                {
                    cell.Text = blueSelected.Text;
                    cell.ForeColor = Color.Blue;
                }
                UpdateTurn();
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

        private void Label3_Click(object sender, EventArgs e)
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
            if(turn == Program.Turn.Blue)
            {
                turnLabel.Text = "Red's Turn";
                turnLabel.ForeColor = Color.Red;
                turn = Program.Turn.Red;
            }
            else if (turn == Program.Turn.Red)
            {
                turnLabel.Text = "Blue's Turn";
                turnLabel.ForeColor = Color.Blue;
                turn = Program.Turn.Blue;
            }
        }

        private void turnLabel_Click(object sender, EventArgs e)
        {

        }
    }
}

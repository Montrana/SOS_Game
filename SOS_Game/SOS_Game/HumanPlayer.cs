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
    internal class HumanPlayer : Player
    {
        public RadioButton SButton { get; protected set; }
        public RadioButton OButton { get; protected set; }
        public HumanPlayer(Color color, RadioButton s, RadioButton o) : base(color)
        {
            IsHuman = true;
            SButton = s;
            OButton = o;
        }

        /// <summary>
        /// Makes a move based on where the player clicks on the board
        /// </summary>
        /// <param name="cell">Cell to Adjust</param>
        /// <param name="gameGrid">The grid the cell is on</param>
        /// <param name="cellIndex">Index of the cell</param>
        /// <returns>true if an SOS was created</returns>
        public bool HumanMoveSelection(Control cell,
            TableLayoutPanel gameGrid, CellIndex cellIndex, out string text)
        {
            text = string.Empty;
            if (SButton.Checked)
            {
                text = "S";
                cell.Text = text;
                cell.ForeColor = PlayerColor;
            }
            else if (OButton.Checked)
            {
                text = "O";
                cell.Text = text;
                cell.ForeColor = PlayerColor;
            }

            int addScore = 0;
            if (cell.Text == "S")
            {
                addScore = PlaceS_CheckSOS(gameGrid, cellIndex);

            }
            else if (cell.Text == "O")
            {
                addScore = PlaceO_CheckSOS(gameGrid, cellIndex);
            }
            if (addScore > 0)
            {
                AddScore(addScore);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

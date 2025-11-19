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

        public bool HumanMoveSelection(Control cell,
            TableLayoutPanel gameGrid, CellIndex cellIndex)
        {
            if (SButton.Checked)
            {
                cell.Text = "S";
                cell.ForeColor = PlayerColor;
            }
            else if (OButton.Checked)
            {
                cell.Text = "O";
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

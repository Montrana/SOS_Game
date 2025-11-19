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
    internal class ComputerPlayer : Player
    {
        
        public ComputerPlayer(Color color) : base(color)
        {
            IsHuman = false;
        }
        public bool ComputerMoveSelection(TableLayoutPanel gameGrid)
        {
            Random rand = new Random();
            string text;
            int gridSize = gameGrid.RowCount;
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    GameScreen.CellIndex cellIndex = new GameScreen.CellIndex
                    {
                        x = i,
                        y = j
                    };
                    Control cell = gameGrid.GetControlFromPosition(cellIndex.x, cellIndex.y);
                    if (cell.Text == "")
                    {
                        if (0 < PlaceS_CheckSOS(gameGrid, cellIndex))
                        {
                            AddScore(PlaceS_CheckSOS(gameGrid, cellIndex));
                            MakeMove(cell, "S");
                            return true;
                        }
                        else if (0 < PlaceS_CheckSOS(gameGrid, cellIndex))
                        {
                            AddScore(PlaceS_CheckSOS(gameGrid, cellIndex));
                            MakeMove(cell, "O");
                            return true;
                        }
                    }
                }
            }
            if (rand.Next(2) == 0)
            {
                text = "S";
            }
            else
            {
                text = "O";
            }
            MakeMove(FindEmptyCell(gameGrid), text);
            return false;
        }

        public Control FindEmptyCell (TableLayoutPanel gameGrid)
        {
            int gridSize = gameGrid.RowCount;
            Control cell;
            do
            {
                Random rand = new Random();
                cell = gameGrid.GetControlFromPosition(
                    rand.Next(gridSize + 1), rand.Next(gridSize + 1));
            }
            while (cell == null || cell.Text != "");
            return cell;
        }
        public void MakeMove(Control cell, string moveSelection)
        {
            if (moveSelection != null)
            {
                cell.Text = moveSelection;
                cell.ForeColor = PlayerColor;
            }
            else
            {
                cell.Text = "S";
                cell.ForeColor = PlayerColor;
            }
        }
    }
}

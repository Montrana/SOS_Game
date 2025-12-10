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
        /// <summary>
        /// Computer player initialization
        /// </summary>
        /// <param name="color">Player color</param>
        public ComputerPlayer(Color color) : base(color)
        {
            IsHuman = false;
        }

        /// <summary>
        /// Computer move selection logic
        /// </summary>
        /// <param name="gameGrid"></param>
        /// <returns>If the computer found a move that creates an SOS</returns>
        public bool ComputerMoveSelection(TableLayoutPanel gameGrid, out CellIndex cellIndex, out string text)
        {
            Random rand = new Random();
            int gridSize = gameGrid.RowCount;
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    cellIndex = new GameScreen.CellIndex
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
                            text = "S";
                            MakeMove(cell, text);
                            return true;
                        }
                        else if (0 < PlaceS_CheckSOS(gameGrid, cellIndex))
                        {
                            AddScore(PlaceS_CheckSOS(gameGrid, cellIndex));
                            text = "O";
                            MakeMove(cell, text);
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
            MakeMove(FindEmptyCell(gameGrid, out cellIndex), text);
            return false;
        }

        /// <summary>
        /// Finds an empty cell if the computer was unsuccesfull with finding a move that creates an SOS
        /// </summary>
        /// <param name="gameGrid"></param>
        /// <returns>The Control for the cell that the computer found</returns>
        public Control FindEmptyCell (TableLayoutPanel gameGrid, out CellIndex index)
        {
            int gridSize = gameGrid.RowCount;
            Control cell;
            do
            {
                Random rand = new Random();
                index.x = rand.Next(gridSize + 1);
                index.y = rand.Next(gridSize + 1);
                cell = gameGrid.GetControlFromPosition(index.x, index.y);
            }
            while (cell == null || cell.Text != "");
            return cell;
        }
        /// <summary>
        /// Updates the cell to reflect the computer's move
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="moveSelection"></param>
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

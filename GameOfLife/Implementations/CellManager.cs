using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    class CellManager : iCellManager
    {
        
        /// <summary>
        /// Public method that will return a grid of the cell states for the next iteration of the game
        /// </summary>
        /// <param name="pGrid"></param>
        public iGrid GetFutureCellStates(iGrid pGridCurrent)
        {
            iGrid gridCurrent = pGridCurrent;

            iGrid gridFuture = pGridCurrent;

            for (int x = 0; x < gridCurrent.grid.GetLength(0); x++)
            {
                for (int y = 0; y < gridCurrent.grid.GetLength(1); y++)
                {
                    gridFuture.grid[x, y] = CheckCellAgainstRules(gridCurrent.GetCell(x, y), GetCellNeighbours(gridCurrent, x, y));
                    
                }
            }

            return gridFuture;
        }
        /// <summary>
        /// Method that checks each of a cells neighbours and returns the number of living cells found
        /// </summary>
        /// <param name="pGrid">Grid to check neighbours in</param>
        /// <param name="pX">X coordinate index for cell to check neighbours of</param>
        /// <param name="pY">Y coordinate index for cell to check neighbours of</param>
        /// <returns></returns>
        private int GetCellNeighbours(iGrid pGrid, int pX, int pY)
        {
            //Declare local variable to store nmber of living cells in neighbours
            int living = 0;

            //adapted from: https://stackoverflow.com/questions/55471955/building-conways-game-of-life-with-c-sharp answer by René Vogt
            //Math.Max prevents issues from checking the edges of the board by preventing negative index values
            for (int x = Math.Max(0, pX - 1); x < pX + 2 && x < pGrid.grid.GetLength(0); x++)
            {
                for (int y = Math.Max(0, pY - 1); y < pY + 2 && y < pGrid.grid.GetLength(1); y++)
                {
                    //Skips counting the current cell
                    if (x == pX && y == pY) continue; 
                    //If the neighbour cell is alive increment living by one
                    if (pGrid.GetCell(x, y).isAlive) { 
                        living++; 
                    }
                    
                }
            }
            return living;
        }

        private iCell CheckCellAgainstRules(iCell pCell, int pLivingNeighbours)
        {
            iCell FutureCell = pCell;
            //If cell has more than 3 or less than 2 living neighbours it dies, or remains dead
            if (pLivingNeighbours > 3 || pLivingNeighbours < 2)
            {
                FutureCell.isAlive = false;
            }
            //if a cell has exactly 2 or 3 living cell neighbours then it will become alive or stay alive.
            else if (pLivingNeighbours == 3)
            {
                FutureCell.isAlive = true;
            }
            return FutureCell;
        }
    }
}

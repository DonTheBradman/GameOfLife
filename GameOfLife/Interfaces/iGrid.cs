using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    /// <summary>
    /// Interface for grid class
    /// </summary>
    interface iGrid
    {
        //Exposes the grid array of iCells so that they can be accessed by the other classes to be manipulated
        public iCell[,] grid { get; set; }
        //Exposes width of grid 
        public int width { get; set; }
        //exposes height of grid
        public int height { get; set; }
        //Exposes the populate grid method, so that the Gridmanager 
        void PopulateGrid();

        iCell GetCell(int pX, int pY);
    }
}

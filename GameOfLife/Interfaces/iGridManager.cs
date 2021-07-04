using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    /// <summary>
    /// Interface class for the GridManager, allowing for the initialisation of current and future grids and for preparing the grids for each iteration
    /// </summary>
    interface iGridManager
    {
        //Public property to access the current grid in the grid manager
        public iGrid currentGrid { get; set; }
        //Public property to access the future grid in the grid manager
        public iGrid futureGrid { get; set; }
        //exposes the setupGrids method so that the kernel can call upon the grid manager to initialise the grids
        void SetupGrids(int pHeight, int pWidth);
        //exposes the SetFutueGridToCurrent method so that the kernel can call upon the grid manager to swap the grids when needed.
        void SetFutureGridToCurrent();





    }
}

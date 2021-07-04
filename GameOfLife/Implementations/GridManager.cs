using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    /// <summary>
    /// Class handles the grids in the program, sets them up and swaps the current and future grid on an iteration.
    /// </summary>
    class GridManager : iGridManager
    {
        //declare variable for current Grid
        public iGrid currentGrid { get { return _currentGrid; } set { _currentGrid = value; } }
        //declar variable for future Grid
        public iGrid futureGrid { get { return _futureGrid; } set { _futureGrid = value; } }

        private iGrid _currentGrid;

        private iGrid _futureGrid;
        //Method to initialise grids, take width, height
        public void SetupGrids(int pWidth, int pHeight)
        {
            //Initialise _currentGrid
            _currentGrid = new Grid(pWidth, pHeight);

            //Initialise _futureGrid
            _futureGrid = new Grid(pWidth, pHeight);

            //Populate currentGrid
            _currentGrid.PopulateGrid();
        }

        //method to set current grid value to future grid and reset future grid for next iteration of the sim
        public void SetFutureGridToCurrent()
        {
            //Zero out the currentGrid array
            //Array.Clear(_currentGrid.grid,0,_currentGrid.grid.Length);

            //set curentGrid equal to futureGrid
            Array.Copy(_futureGrid.grid, _currentGrid.grid, _currentGrid.grid.Length);
            //Clear the futureGrid array ready for the next iteration
            _futureGrid = new Grid(_futureGrid.width, _futureGrid.height);
        }

    }
}

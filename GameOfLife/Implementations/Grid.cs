using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    class Grid: iGrid
    {
        public iCell[,] grid { get { return _grid; } set { _grid = value; } }

        public int width { get { return _width; } set { _width = value; } }

        public int height { get { return _height; } set { _height = value; } }

        private iCell[,] _grid;

        private int _width;

        private int _height;

        private Random Rand = new Random();
        public Grid(int pWidth, int pHeight)
        {
            //Conditional to check that valid parameters for grid creation are passed in
            if ( pWidth == null || pHeight == null || (pWidth <= 0 || pHeight <= 0))
            {
                throw new ArgumentOutOfRangeException("Height and width must not be null and must be greater than 0");
            }
            else
            {
                //initialise grid with passed in width and height parameters
                _grid = new iCell[pWidth, pHeight];
                _width = pWidth;
                _height = pHeight;
            }
        }
        /// <summary>
        /// Helper method to get the reference to an iCell of a specific coordinate
        /// </summary>
        /// <param name="pX"></param>
        /// <param name="pY"></param>
        /// <returns></returns>
        public iCell GetCell(int pX, int pY)
        {
            if (_grid.Length > 0)
            {
                return _grid[pX, pY];
            }
            else
            {
                throw new NullReferenceException("Grid has not been initialised, length is not greater than 0");
            }
            
        }

        /// <summary>
        /// Method to populate the instantiated grid with new cells and assign random status values to them.
        /// </summary>
        public void PopulateGrid()
        {
            iCell newCell;
            
            for (int x = 0; x < _grid.GetLength(0); x++)
            {
                for (int y = 0; y < _grid.GetLength(1); y++)
                {
                    newCell = new Cell();
                    //Set new cell to alive or dead
                    newCell.isAlive = SetCellStatus();
                    //assign cell to grid
                    _grid[x, y] = newCell;
                }
            }

        }

        /// <summary>
        /// Helper class to get new random number 0 or 1 then return a bool accordingly
        /// </summary>
        /// <returns></returns>
        private bool SetCellStatus()
        {
            return Rand.Next(2) == 1 ? true : false;
        }
        
    }
}

using System;

namespace GameOfLife
{
    //Class responsible for setting up and running the game of life
    class Kernel
    {
        
        private iGridManager _gridManager;
        private iCellManager _cellManager;

        private bool continuousRun = true;
        /// <summary>
        /// Constructor for kernel, initialises passed in components
        /// </summary>
        /// <param name="pGridManager">Injected Grid manager</param>
        /// <param name="pCellManager">Injected Cell manager</param>
        public Kernel(iGridManager pGridManager, iCellManager pCellManager)
        {

            _gridManager =  pGridManager;

            _cellManager = pCellManager;
        }
        /// <summary>
        /// Calls on the grid manager to initialise grids on a default 10/10 sized grid
        /// </summary>
        public void SetupGame()
        {
            //Set up the game grids determined by width/height parameters
            _gridManager.SetupGrids(20, 20);
        }

        /// <summary>
        /// Override for the setupgame method that allows user input for the grid sizes
        /// </summary>
        /// <param name="pWidth"></param>
        /// <param name="pHeight"></param>
        public void SetupGame(int pWidth, int pHeight)
        {
            if (pHeight > 0 || pWidth > 0 )
            {
                //Set up the game grids determined by width/height parameters
                _gridManager.SetupGrids(pHeight, pWidth);

            }
            else
            {
               throw new ArgumentOutOfRangeException("Grid size must be greater than 0 and an integer.");
                
            }
            
            
        }
        /// <summary>
        /// Runs the Game a number of iterations, passed in as parameter
        /// </summary>
        /// <param name="pIterations">Number of iterations to perform</param>
        public void RunGame(int pIterations)
        {
            int iterations = pIterations;
            
            Console.WriteLine("---INITIAL SEED ---");
            DisplayGrid(_gridManager.currentGrid);

            //If iterations are valid
            if (iterations > 0)
                {

                    for (int i = 0; i < iterations; i++)
                    {
                    //Run Iterations    
                    Console.WriteLine("---ITERATION {0} ---", i);
                    //set future grid depending on cell neighbour statuses
                    _gridManager.futureGrid = _cellManager.GetFutureCellStates(_gridManager.currentGrid);
                    //set the new future grid as the current grid
                    _gridManager.SetFutureGridToCurrent();
                    //display the new grid iteration
                    DisplayGrid(_gridManager.currentGrid);
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("Number of iterations must be greater than 0 and an integer.");
            }

        }
        /// <summary>
        /// Method that displays the grid onto the console
        /// </summary>
        /// <param name="pGrid">Grid to display</param>
        private void DisplayGrid(iGrid pGrid)
        {
            //Console.Clear();
            for (int x = 0; x < pGrid.grid.GetLength(1); x++)
            {
                for (int y = 0; y < pGrid.grid.GetLength(0); y++)
                {
                    if (pGrid.grid[x, y].isAlive)
                    {
                        //Write O to console is cell is alive
                        Console.Write(string.Format("{0} ", "O"));
                    }
                    else
                    {
                        //Write X to console if cell is dead
                        Console.Write(string.Format("{0} ", "X"));
                    }
                    
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }

        }



    }
}

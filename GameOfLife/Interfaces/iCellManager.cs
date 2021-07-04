using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    /// <summary>
    /// Interface for the cell manager class
    /// </summary>
    interface iCellManager
    {
        /// <summary>
        /// Exposes the GetFutureCellStates method so that a new futureGrid can be returned to the gridmanager when needed
        /// </summary>
        /// <param name="pGridCurrent">A reference to the current grid</param>
        /// <returns>Returns an iGrid to be assigned to the future grid in gridmanager</returns>
        public iGrid GetFutureCellStates(iGrid pGridCurrent);

    }
}

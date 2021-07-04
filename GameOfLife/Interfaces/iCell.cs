using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    /// <summary>
    /// Interface class for the Cell object
    /// </summary>
    interface iCell
    {
        //Boolean determining if a cell is "alive" (1) or "dead" (0)
        bool isAlive { get; set; }

    }
}

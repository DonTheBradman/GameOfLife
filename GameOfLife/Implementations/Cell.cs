using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    /// <summary>
    /// Cell class implementing the iCell interface
    /// </summary>
    class Cell : iCell
    {
        //Public property bool for cells status
        public bool isAlive { get { return _isAlive; } set { _isAlive = value; } }

        //private bool for cells status, for use internally in the class
        private bool _isAlive;

        //Constuctor for cell, sets a value for _isAlive on instantiation
        public Cell()
        {
            Random rand = new Random();
            //Gets random number 0 or 1, then sets bool accordingly
            _isAlive = rand.Next(0, 2) == 1 ? true : false ;
        }
        //method to check againt rules to see this cells future
    }
}

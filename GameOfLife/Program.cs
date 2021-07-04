using System;

namespace GameOfLife
{
    class Program
    {

        private static Kernel _kernel;

        static void Main(string[] args)
        {
            _kernel = new Kernel(new GridManager() , new CellManager() );

            _kernel.SetupGame();

            _kernel.RunGame(10);



        }
    }
}

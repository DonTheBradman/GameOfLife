using System;

namespace GameOfLife
{
    class Program
    {

        private static Kernel _kernel;

        static void Main(string[] args)
        {
            //Create a new kernel object and inject the gridmanager and cell manager
            _kernel = new Kernel(new GridManager() , new CellManager() );

            _kernel.SetupGame();
            

            try
            {
                
                Console.WriteLine("How many iterations should the game run for: ");
                int iterations = int.Parse(Console.ReadLine());

                // runs the game for x iterations
                _kernel.RunGame(iterations);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine("Input error: reverting to default values");

                _kernel.RunGame(3);
            }
            



        }
    }
}

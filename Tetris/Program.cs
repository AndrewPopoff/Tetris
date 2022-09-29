using System;
using System.Threading;

namespace Tetris
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(40, 30);
            Console.SetBufferSize(40, 30);

            FigureGenerator gen = new FigureGenerator(20, 0, '*');
            Figure currentFigure = gen.GetNewFigure();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    HandleKey(currentFigure, keyInfo);
                }
            }
        }

        private static void HandleKey(Figure currentFigure, ConsoleKeyInfo keyInfo)
        {
            switch(keyInfo.Key)
            {
                case ConsoleKey.LeftArrow:
                    currentFigure.Move(Direction.LEFT);
                    break;
                case ConsoleKey.RightArrow:
                    currentFigure.Move(Direction.RIGHT);
                    break;
                case ConsoleKey.DownArrow:
                    currentFigure.Move(Direction.DOWN);
                    break;
            }
        }
    }
}

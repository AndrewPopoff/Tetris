using System;
using System.Threading;

namespace Tetris
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(Field.Width, Field.Height);
            Console.SetBufferSize(Field.Width, Field.Height);

            Field.Width = 50;

            FigureGenerator gen = new FigureGenerator(Field.Width / 2, 0, '*');
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
                    currentFigure.TryMove(Direction.LEFT);
                    break;
                case ConsoleKey.RightArrow:
                    currentFigure.TryMove(Direction.RIGHT);
                    break;
                case ConsoleKey.DownArrow:
                    currentFigure.TryMove(Direction.DOWN);
                    break;
                case ConsoleKey.Spacebar:
                    currentFigure.TryRotate();
                    break;
            }
        }
    }
}

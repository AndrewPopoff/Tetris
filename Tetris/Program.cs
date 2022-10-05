using System;
using System.Threading;

namespace Tetris
{
    class Program
    {
        private static FigureGenerator gen = null;
        static void Main(string[] args)
        {
            Console.SetWindowSize(Field.Width + 1, Field.Height);
            Console.SetBufferSize(Field.Width + 1, Field.Height);

            gen = new FigureGenerator(Field.Width / 2, 0, Drawer.DEFAULT_SYMBOL);
            Figure currentFigure = gen.GetNewFigure();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    var result = HandleKey(currentFigure, keyInfo);
                    ProcessResult(result, ref currentFigure);
                }
            }
        }

        private static bool ProcessResult(Result result, ref Figure currentFigure)
        {
            if (result == Result.HEAP_STRIKE || result == Result.DOWN_BORDER_STRIKE)
            {
                Field.AddFigure(currentFigure);
                Field.TryDeleteLines();
                currentFigure = gen.GetNewFigure();
                return true;
            }
            else
                return false;
        }

        private static Result HandleKey(Figure currentFigure, ConsoleKeyInfo keyInfo)
        {
            switch(keyInfo.Key)
            {
                case ConsoleKey.LeftArrow:
                    return currentFigure.TryMove(Direction.LEFT);
                case ConsoleKey.RightArrow:
                    return currentFigure.TryMove(Direction.RIGHT);
                case ConsoleKey.DownArrow:
                    return currentFigure.TryMove(Direction.DOWN);
                case ConsoleKey.Spacebar:
                    return currentFigure.TryRotate();
            }
            return Result.SUCCESS;
        }
    }
}

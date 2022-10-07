using System;
using System.Threading;
using System.Timers;

namespace Tetris
{
    class Program
    {
        private static FigureGenerator gen;
        private static Figure currentFigure;

        const int TIMER_INTERVAL = 500;
        static System.Timers.Timer timer;

        static private Object _lockObject = new object();

        static void Main(string[] args)
        {
            DrawerProvider.Drawer.InitField();

            gen = new FigureGenerator(Field.Width / 2, 0);
            currentFigure = gen.GetNewFigure();

            SetTimer();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    Monitor.Enter(_lockObject);
                    var result = HandleKey(currentFigure, keyInfo);
                    ProcessResult(result, ref currentFigure);
                    Monitor.Exit(_lockObject);
                }
            }
        }

        private static void SetTimer()
        {
            timer = new System.Timers.Timer(TIMER_INTERVAL);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private static void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            Monitor.Enter(_lockObject);
            var result = currentFigure.TryMove(Direction.DOWN);
            ProcessResult(result, ref currentFigure);
            Monitor.Exit(_lockObject);
        }

        private static bool ProcessResult(Result result, ref Figure currentFigure)
        {
            if (result == Result.HEAP_STRIKE || result == Result.DOWN_BORDER_STRIKE)
            {
                Field.AddFigure(currentFigure);
                Field.TryDeleteLines();

                if(currentFigure.IsOnTop())
                {
                    timer.Elapsed -= OnTimedEvent;
                    WriteGameOver();
                    return true;
                }

                currentFigure = gen.GetNewFigure();
                return true;
            }
            else
                return false;
        }

        private static void WriteGameOver()
        {
            DrawerProvider.Drawer.WriteGameOver();
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

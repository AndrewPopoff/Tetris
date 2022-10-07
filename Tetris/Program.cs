using System;
using System.Threading;
using System.Timers;

namespace Tetris
{
    class Program
    {
        private static FigureGenerator gen = null;
        private static Figure currentFigure = null;

        const int TIMER_INTERVAL = 500;
        static System.Timers.Timer timer;

        static private Object _lockObject = new object();

        static void Main(string[] args)
        {
            Console.SetWindowSize(Field.Width + 1, Field.Height);
            Console.SetBufferSize(Field.Width + 1, Field.Height);

            Test();

            gen = new FigureGenerator(Field.Width / 2, 0, Drawer.DEFAULT_SYMBOL);
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

        private static void Test()
        {
            DrawerProvider.Drawer.DrawPoint(10, 4);
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
            Console.SetCursorPosition(Field.Width / 2 - 8, Field.Height / 2);
            Console.WriteLine("G A M E   O V E R");
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

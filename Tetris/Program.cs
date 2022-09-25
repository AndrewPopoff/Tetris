using System;

namespace Tetris
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(40, 30);
            Console.SetBufferSize(40, 30);

            Point p1 = new Point();
            p1.x = 2;
            p1.y = 3;
            p1.c = '*';
            p1.Draw();

            Point p2 = new Point();
            p2.x = 12;
            p2.y = 23;
            p2.c = '*';
            p2.Draw();

            Console.ReadKey();
        }

    }
}

using System;

namespace Tetris
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(40, 30);
            Console.SetBufferSize(40, 30);

            Point p1 = new Point(2,3,'*');
            p1.Draw();

            Figure[] figures = new Figure[2];
            figures[0] = new Square(10, 20, '*');
            figures[1] = new Stick(7, 7, '#');

            figures[0].Draw();
            figures[1].Draw();

            Console.ReadKey();
        }

    }
}

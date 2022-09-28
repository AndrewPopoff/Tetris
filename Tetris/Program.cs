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
            Figure s = gen.GetNewFigure();

            //Figure s = new Stick(2, 5, '*');
            s.Draw();
            Thread.Sleep(500);

            s.Hide();
            s.Rotate();
            s.Draw();
            Thread.Sleep(500);

            s.Hide();
            s.Move(Direction.RIGHT);
            s.Draw();
            Thread.Sleep(500);
            s.Hide();
            s.Move(Direction.DOWN);
            s.Draw();
            Thread.Sleep(500);
            s.Hide();
            s.Move(Direction.RIGHT);
            s.Draw();


            //Point p1 = new Point(2,3,'*');
            //p1.Draw();

            //Figure[] figures = new Figure[2];
            //figures[0] = new Square(10, 20, '*');
            //figures[1] = new Stick(7, 7, '#');

            //figures[0].Draw();
            //figures[1].Draw();

            Console.ReadKey();
        }

    }
}

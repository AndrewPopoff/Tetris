using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char C { get; set; }

        public Point()
        {

        }
        public Point(int x,int y, char c)
        {
            this.X = x;
            this.Y = y;
            this.C = c;
        }

        public Point(Point point)
        {
            X = point.X;
            Y = point.Y;
            C = point.C;
        }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(C);
            Console.SetCursorPosition(0, 0);
        }

        public void Move(Direction d)
        {
            switch (d)
            {
                case Direction.RIGHT:
                    X += 1;
                    break;
                case Direction.LEFT:
                    X -= 1;
                    break;
                case Direction.DOWN:
                    Y += 1;
                    break;
            }
        }

        public void Hide()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(" ");
        }
    }
}

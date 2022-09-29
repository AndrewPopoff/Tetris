using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    public class Point
    {
        public int x;
        public int y;
        public char c;

        public Point()
        {

        }
        public Point(int x,int y, char c)
        {
            this.x = x;
            this.y = y;
            this.c = c;
        }

        public Point(Point point)
        {
            x = point.x;
            y = point.y;
            c = point.c;
        }

        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(c);
            Console.SetCursorPosition(0, 0);
        }

        public void Move(Direction d)
        {
            switch (d)
            {
                case Direction.RIGHT:
                    x += 1;
                    break;
                case Direction.LEFT:
                    x -= 1;
                    break;
                case Direction.DOWN:
                    y += 1;
                    break;
            }
        }

        public void Hide()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }
    }
}

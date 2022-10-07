using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point()
        {

        }
        public Point(int x,int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Point(Point point)
        {
            X = point.X;
            Y = point.Y;
        }

        public void Draw()
        {
            DrawerProvider.Drawer.DrawPoint(X, Y);
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
            DrawerProvider.Drawer.HidePoint(X, Y);
        }
    }
}

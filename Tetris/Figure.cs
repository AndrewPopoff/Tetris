using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    public abstract class Figure
    {
        public Point[] points = new Point[4];
        public void Draw()
        {
            foreach (Point p in points)
                p.Draw();
        }
        public void Move(Direction d)
        {
            foreach(Point p in points)
            {
                p.Move(d);
            }
        }

        public abstract void Rotate();

        public void Hide()
        {
            foreach(Point p in points)
            {
                p.Hide();
            }
                
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    public abstract class Figure
    {
        const int FIGURE_SIZE = 4;
        public Point[] points = new Point[FIGURE_SIZE];
        public void Draw()
        {
            foreach (Point p in points)
                p.Draw();
        }
        public void TryMove(Direction dir)
        {
            Hide();
            var clone = Clone();
            Move(clone,dir);
            if (VerifyPosition(clone))
                points = clone;
            Draw();
        }

        public void TryRotate()
        {
            Hide();
            var clone = Clone();
            Rotate(clone);
            if (VerifyPosition(clone))
                points = clone;
            Draw();
        }

        private bool VerifyPosition(Point[] pList)
        {
            foreach(Point p in pList)
            {
                if (p.x < 0 || p.y < 0 || p.x >= Field.WIDTH || p.y >= Field.WIDTH)
                    return false;
            }
            return true; 
        }

        public void Move(Point[] pList, Direction dir)
        {
            foreach (Point p in pList)
            {
                p.Move(dir);
            }
        }

        private Point[] Clone()
        {
            var newPoints = new Point[FIGURE_SIZE];
            for (int i = 0; i < FIGURE_SIZE; i++)
                newPoints[i] = new Point(points[i]);
            return newPoints;
        }


        //public void Move(Direction d)
        //{
        //    Hide();
        //    foreach(Point p in points)
        //    {
        //        p.Move(d);
        //    }
        //    Draw();
        //}

        public abstract void Rotate(Point[] pList);

        public void Hide()
        {
            foreach(Point p in points)
            { 
                p.Hide();
            }
                
        }

    }
}

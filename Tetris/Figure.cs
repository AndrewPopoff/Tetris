using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    public abstract class Figure
    {
        const int FIGURE_SIZE = 4;
        public Point[] Points = new Point[FIGURE_SIZE];
        public void Draw()
        {
            foreach (Point p in Points)
                p.Draw();
        }
        public void TryMove(Direction dir)
        {
            Hide();
            var clone = Clone();
            Move(clone,dir);
            if (VerifyPosition(clone))
                Points = clone;
            Draw();
        }

        public void TryRotate()
        {
            Hide();
            var clone = Clone();
            Rotate(clone);
            if (VerifyPosition(clone))
                Points = clone;
            Draw();
        }

        private bool VerifyPosition(Point[] pList)
        {
            foreach(Point p in pList)
            {
                if (p.X < 0 || p.Y < 0 || p.X >= Field.Width || p.Y >= Field.Height)
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
                newPoints[i] = new Point(Points[i]);
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
            foreach(Point p in Points)
            { 
                p.Hide();
            }
                
        }

    }
}

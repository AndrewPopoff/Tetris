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
        public Result TryMove(Direction dir)
        {
            Hide();
            var clone = Clone();
            Move(clone,dir);
            Result result = VerifyPosition(clone);
            if (result == Result.SUCCESS)
                Points = clone;
            Draw();

            return result;
        }

        public Result TryRotate()
        {
            Hide();
            var clone = Clone();
            Rotate(clone);
            var result = VerifyPosition(clone);
            if (result == Result.SUCCESS)
                Points = clone;
            Draw();

            return result;
        }

        private Result VerifyPosition(Point[] pList)
        {
            foreach(Point p in pList)
            {
                if (p.Y >= Field.Height)
                    return Result.DOWN_BORDER_STRIKE;

                if (p.X < 0 || p.Y < 0 || p.X >= Field.Width)
                    return Result.BORDER_STRIKE;

                if (Field.CheckStrike(p))
                    return Result.HEAP_STRIKE;
            }

            return Result.SUCCESS; 
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

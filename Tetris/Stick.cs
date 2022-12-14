using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    class Stick : Figure
    {
        public Stick(int x, int y)
        {
            Points[0] = new Point(x, y);
            Points[1] = new Point(x, y + 1);
            Points[2] = new Point(x, y + 2);
            Points[3] = new Point(x, y + 3);
            Draw();
        }
        public override void Rotate(Point[] pList)
        {
            if(pList[0].X == pList[1].X) //вертикальная палка
            {
                RotateToHoriz(pList);
            }
            else // горизонтальная палка
            {
                RotateToVert(pList);
            }
        }

        private void RotateToVert(Point[] pList)
        {
            for (int i = 0; i < pList.Length; i++)
            {
                pList[i].X = pList[0].X;
                pList[i].Y = pList[0].Y + i;
            }
        }

        private void RotateToHoriz  (Point[] pList)
        {
            for(int i = 0; i < pList.Length; i ++)
            {
                pList[i].Y = pList[0].Y;
                pList[i].X = pList[0].X + i;
            }
        }
    }
}

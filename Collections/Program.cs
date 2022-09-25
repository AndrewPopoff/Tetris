using System;
using Tetris;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums1 = new int[5];
            nums1[0] = 1;
            nums1[1] = 2;

            //for (int i = 0; i < nums1.Length; i++)
            //    Console.WriteLine(nums1[i]);

            //foreach (int a in nums1)
            //    Console.WriteLine(a);

            Point[] points = new Point[3];
            points[0] = new Point(1, 2, '*');
            points[1] = new Point(3, 4, '#');
            points[2] = new Point(5, 6, '*');

            //foreach (Point p in points)
            //    p.Draw();

            char[][] field = new char[3][];
            field[0] = new char[3];
            field[1] = new char[3];
            field[2] = new char[3];
            field[0][0] = 'x';
            field[2][2] = '0';

            for(int i=0;i<field.Length;i++)
                for(int j = 0; j < field[i].Length;j++)
                {
                    if (!(field[i][j] == 'x' || field[i][j] == '0'))
                        field[i][j] = 'y';

                    Point p = new Point(i, j, field[i][j]);
                    p.Draw();
                }    
            Console.ReadKey();
        }
    }
}

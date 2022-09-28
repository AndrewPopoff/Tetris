﻿using System;
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
            Figure s = null;

            while (true)
            {
                FigureFall(out s,gen);
                s.Draw();
            }
        }

        static void FigureFall(out Figure fig, FigureGenerator gen)
        {
            fig = gen.GetNewFigure();
            fig.Draw();

            for (int i = 0; i < 15; i++)
            {
                fig.Hide();
                fig.Move(Direction.DOWN);
                fig.Draw();
                Thread.Sleep(200);
            }
        }
    }
}

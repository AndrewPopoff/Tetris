using System;

namespace Randomizer
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int val = random.Next(0, 10);

            for (int j = 0;j < 20;j++)
                Console.WriteLine(random.Next(0,10));

        }
    }
}

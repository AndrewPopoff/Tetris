using System;

namespace Enums
{
    class Program
    {
        static void Main(string[] args)
        {
            Day day = Day.Sun;

            if (day == Day.Sun)
                Console.WriteLine($"вск: {(int)Day.Sun}" );
        }
    }
}

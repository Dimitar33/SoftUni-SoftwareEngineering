using System;

namespace _02._Center_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            int x1 = int.Parse(Console.ReadLine());
            int y1 = int.Parse(Console.ReadLine());
            int x2 = int.Parse(Console.ReadLine());
            int y2 = int.Parse(Console.ReadLine());

            

            closestPointTo0(x1, x2, y1, y2);


        }

        public static void closestPointTo0(int x1, int x2, int y1, int y2)
        {
         

            double first = Math.Sqrt(Math.Pow(y1, 2) + Math.Pow(x1, 2));
            double secound = Math.Sqrt(Math.Pow(y2, 2) + Math.Pow(x2, 2));

            if (first < secound)
            {
                Console.WriteLine($"({x1}, {y1})");
            }
            else if (first == secound)
            {
                Console.WriteLine($"({x1}, {y1})");
            }
            else
            {
                Console.WriteLine($"({x2}, {y2})");
            }

        }
    }
}

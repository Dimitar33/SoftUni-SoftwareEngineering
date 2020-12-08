using System;

namespace _6._Calculate_Rectangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double hight = double.Parse(Console.ReadLine());

            rectangleArea(width, hight);
            double area = rectangleArea(width, hight);
            Console.WriteLine(area);
        }

        private static double rectangleArea(double width, double hight)
        {
            double area = width * hight;

            return area;
        }
    }
}

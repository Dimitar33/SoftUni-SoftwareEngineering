using System;

namespace _01.ClassBoxData
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            Box box = new Box(length, width, height);

            Console.WriteLine($"Surface Area - {box.SurfaceArea()}");
            Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceArea()}");
            Console.WriteLine($"Volume - {box.Volume()}");
        }
    }
}

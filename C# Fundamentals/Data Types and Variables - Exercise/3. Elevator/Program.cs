using System;

namespace _3._Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int elevatorCapacity = int.Parse(Console.ReadLine());
            int ppCount = int.Parse(Console.ReadLine());

            double courses = Math.Ceiling(elevatorCapacity / (double)ppCount);

            Console.WriteLine(courses);
        }
    }
}

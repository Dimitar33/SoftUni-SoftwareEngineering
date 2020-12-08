using System;

namespace _3._30_June_2019_Group_1._Distance_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double stepsMade = double.Parse(Console.ReadLine());
            double stepLenght = double.Parse(Console.ReadLine());
            double neededDistance = double.Parse(Console.ReadLine());

            neededDistance *= 100;
            double distance = 0;

            for (int i = 1; i <= stepsMade; i++)
            {
                if (i % 5 == 0)
                {
                    distance += stepLenght * 0.7;
                }
                else
                {
                    distance += stepLenght;
                }

            }
            double percent = distance / neededDistance * 100;

            Console.WriteLine($"You travelled {percent:f2}% of the distance!");
        }
    }
}

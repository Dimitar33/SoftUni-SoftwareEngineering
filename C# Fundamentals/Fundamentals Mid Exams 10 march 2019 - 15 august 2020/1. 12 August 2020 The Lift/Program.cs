using System;
using System.Linq;

namespace _1._12_August_2020_The_Lift
{
    class Program
    {
        static void Main(string[] args)
        {
            int pplWaitng = int.Parse(Console.ReadLine());
            int[] wagons = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < wagons.Length; i++)
            {
                while (wagons[i] < 4)
                {
                    wagons[i]++;
                    pplWaitng--;
                    if (pplWaitng < 1)
                    {
                        if (wagons.Sum() / wagons.Length == 4)
                        {
                            Console.WriteLine(string.Join (" " , wagons));
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.WriteLine("The lift has empty spots!");
                            Console.WriteLine(string.Join(" ", wagons));
                            Environment.Exit(0);
                        }
                    }
                }
            }
            Console.WriteLine($"There isn't enough space! {pplWaitng} people in a queue!");
            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}

using System;

namespace _1._29_February_2020_Group_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int emp1 = int.Parse(Console.ReadLine());
            int emp2 = int.Parse(Console.ReadLine());
            int emp3 = int.Parse(Console.ReadLine());
            int ppl = int.Parse(Console.ReadLine());

            int hours = 0;
            int emPower = emp1 + emp2 + emp3;

            while (ppl > 0 )
            {
                ppl -= emPower;
                hours++;
                if (hours % 4 == 0)
                {
                    hours++;
                }
            }
            Console.WriteLine($"Time needed: {hours}h.");
        }
    }
}

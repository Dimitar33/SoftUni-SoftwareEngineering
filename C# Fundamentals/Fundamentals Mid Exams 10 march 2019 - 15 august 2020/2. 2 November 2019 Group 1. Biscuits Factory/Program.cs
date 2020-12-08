using System;

namespace _2._2_November_2019_Group_1._Biscuits_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            double buscuitPerWorker = double.Parse(Console.ReadLine());
            double workers = double.Parse(Console.ReadLine());
            double competitorProduction = double.Parse(Console.ReadLine());
            double loses = 0;

            double production = buscuitPerWorker * workers * 20;
            for (int i = 3; i <= 30; i += 3)
            {
                loses += Math.Floor((buscuitPerWorker * workers ) * 0.75);
            }
            production += loses;

            Console.WriteLine($"You have produced {production} biscuits for the past month.");
            double diff = Math.Abs(production - competitorProduction);
            double percent = diff / competitorProduction * 100;

            if (production > competitorProduction)
            {
                Console.WriteLine($"You produce {percent:f2} percent more biscuits.");
            }
            else
            {
                Console.WriteLine($"You produce {percent:f2} percent less biscuits.");

            }

        }
    }
}

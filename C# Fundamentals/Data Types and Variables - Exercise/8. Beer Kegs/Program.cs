using System;

namespace _8._Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string bigestKeg = "";
            double bigestVolume = 0;
            for (int i = 0; i < n; i++)
            {
                string kegModel = Console.ReadLine();
                double kegRadius = double.Parse(Console.ReadLine());
                int kegHigh = int.Parse(Console.ReadLine());
                
                double volume = Math.PI * Math.Pow(kegRadius, 2) * kegHigh;

                if (volume > bigestVolume)
                {
                    bigestVolume = volume;
                    bigestKeg = kegModel;
                }
            }
            Console.WriteLine(bigestKeg);
        }
    }
}

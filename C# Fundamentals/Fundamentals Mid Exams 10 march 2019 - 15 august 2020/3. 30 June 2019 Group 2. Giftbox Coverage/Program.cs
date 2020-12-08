using System;
using System.Runtime.InteropServices;

namespace _3._30_June_2019_Group_2._Giftbox_Coverage
{
    class Program
    {
        static void Main(string[] args)
        {
            double sideSize = double.Parse(Console.ReadLine());
            double sheetsCount = double.Parse(Console.ReadLine());
            double coveragePerSheet = double.Parse(Console.ReadLine());

            double coverage = 0;
            double area = sideSize * sideSize * 6;

            for (int i = 1; i <= sheetsCount; i ++)
            {
                if (i % 3 == 0)
                {
                    coverage += coveragePerSheet * 0.25;
                }
                else
                {
                    coverage += coveragePerSheet;
                }
            }
            double percent = coverage / area * 100;

            Console.WriteLine($"You can cover {percent:f2}% of the box.");

        }
    }
}

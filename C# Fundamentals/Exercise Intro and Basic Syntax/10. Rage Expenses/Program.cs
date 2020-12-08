using System;

namespace _10._Rage_Expenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int loses = int.Parse(Console.ReadLine());
            double hedsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());
            int hsCount = 0;
            int keyCount = 0;
            int disCount = 0;
            int mouseCount = 0;

            for (int i = 1; i <= loses; i++)
            {
                if (i % 2 == 0)
                {
                    hsCount++;
                }
                if (i % 3 == 0)
                {
                    mouseCount++;
                }
                if (i % 6 == 0)
                {
                    keyCount++;
                }
                if (i % 12 == 0)
                {
                    disCount++;
                }
            }

            double total = hsCount * hedsetPrice + mouseCount * mousePrice + keyCount * keyboardPrice + disCount * displayPrice;

            Console.WriteLine($"Rage expenses: {total:f2} lv.");
        }
    }
}

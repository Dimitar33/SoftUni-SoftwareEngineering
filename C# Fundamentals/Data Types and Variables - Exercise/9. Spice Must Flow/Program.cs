using System;

namespace _9._Spice_Must_Flow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingYeld = int.Parse(Console.ReadLine());
            int sum = 0;
            int count = 0;
            while (startingYeld > 99)
            {
                sum += startingYeld;
                sum -= 26;
                startingYeld -= 10;
                count++;
            }
            sum -= 26;
            if (sum < 0)
            {
                sum = 0;
            }
            Console.WriteLine(count);
            Console.WriteLine(sum);
        }
    }
}

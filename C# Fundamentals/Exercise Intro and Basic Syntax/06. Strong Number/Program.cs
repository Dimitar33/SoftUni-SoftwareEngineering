using System;

namespace _06._Strong_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int total = 0;
            int firstNum = num;

            while (num > 0)
            {
                int sum = 1;
                int n = num % 10;
                for (int i = 0; i < n-1; i++)
                {
                 sum *= n - i ;

                }
                total += sum;
                num /= 10;
            }

            if (total == firstNum)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
            
        }
    }
}

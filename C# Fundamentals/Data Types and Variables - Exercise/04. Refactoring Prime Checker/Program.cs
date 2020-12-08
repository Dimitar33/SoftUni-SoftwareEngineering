using System;

namespace _04._Refactoring_Prime_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            for (int i = 2; i <= n; i++)
            {
                bool flag = true;

                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        flag = false;
                        break;
                    }
                }
                Console.WriteLine($"{i} -> {flag.ToString().ToLower()}");
            }

        }
    }
}

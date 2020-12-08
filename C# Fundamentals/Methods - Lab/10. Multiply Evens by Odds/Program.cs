using System;

namespace _10._Multiply_Evens_by_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            n = Math.Abs(n);

            int result = GetMultipleOfEvenAndOdds(n);
            int evenSum = GetSumOfEvenDigits(n);
            int oddSum = GetSumOfOddDigits(n);

            Console.WriteLine(result);
        }

        private static int GetSumOfOddDigits(int n)
        {
            int oddSum = 0;
            int odd = 0;

            while (n > 0)
            {
                odd = n % 10;
                if (odd % 2 != 0)
                {
                    oddSum += n % 10;
                }
                n /= 10;
            }
            return oddSum;
        }

        private static int GetSumOfEvenDigits(int n)
        {
            int even = 0;
            int evenSum = 0;
            while (n > 0)
            {
                even = n % 10;
                if (even % 2 == 0)
                {
                    evenSum += n % 10;
                }
                n /= 10;
            }
            return evenSum;
        }

        private static int GetMultipleOfEvenAndOdds(int n)
        {
            int result = GetSumOfEvenDigits(n) * GetSumOfOddDigits(n);

            return result;
        }
    }
}

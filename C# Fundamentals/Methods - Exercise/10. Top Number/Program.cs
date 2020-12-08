using System;
using System.Linq;

namespace _10._Top_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string temp =  i.ToString();
                int[] digits = temp.Select(temp => Convert.ToInt32(temp.ToString())).ToArray();

                if (digits.Sum() % 8 == 0)
                {
                    for (int j = 0; j < digits.Length; j++)
                    {
                        if (digits[j] % 2 != 0)
                        {
                            Console.WriteLine(i);
                            break;
                        }
                    }
                }
            }
         
        }
    }
}

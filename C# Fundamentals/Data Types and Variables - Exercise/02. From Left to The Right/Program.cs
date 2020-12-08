using System;
using System.Linq;

namespace _02._From_Left_to_The_Right
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                long[] num = Console.ReadLine().Split(" ").Select(long.Parse).ToArray();


                if (num[0] > num[1])
                {
                    num[0] = Math.Abs(num[0]);
                    string word = num[0].ToString();

                    for (int j = 0; j < word.Length; j++)
                    {
                        sum += int.Parse(word[j].ToString());
                    }
                }
                else
                {
                    num[1] = Math.Abs(num[1]);
                    string word = num[1].ToString();

                    for (int j = 0; j < word.Length; j++)
                    {
                        sum += int.Parse(word[j].ToString());
                    }
                }

                Console.WriteLine(sum);
            }
        }
    }
}

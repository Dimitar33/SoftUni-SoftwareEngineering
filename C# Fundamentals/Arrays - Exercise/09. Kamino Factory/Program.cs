using System;
using System.Linq;

namespace _09._Kamino_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            string sequenses = Console.ReadLine();
            int bestCount = 0;           
            int[] bestFullDna = new int[0];
            int bestIndex = 0;
            int bestSum = 0;
            int bestSample = 0;
            int sample = 0;

            while (sequenses != "Clone them!")
            {
                int[] arr = sequenses.Split("!", StringSplitOptions.RemoveEmptyEntries)
                         .Select(int.Parse).ToArray();
                sample++;

                for (int i = 0; i < arr.Length; i++)
                {
                    
                    int count = 0;
                    int[] fullDna = arr;
                    int sum = arr.Sum();

                    for (int j = i; j < arr.Length; j++)
                    {
                        if (arr[j] == 1)
                        {                          
                            count++;
                            int index = i;

                            if (count > bestCount ||
                               (count == bestCount && index < bestIndex) ||
                               (count == bestCount && index == bestIndex &&
                               sum > bestSum))
                            {
                                
                                bestCount = count;
                                bestFullDna = fullDna;
                                bestIndex = index;
                                bestSum = sum;
                                bestSample = sample;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                sequenses = Console.ReadLine();
            }
            Console.WriteLine($"Best DNA sample {bestSample} with sum: {bestSum}.");
            Console.WriteLine(string.Join(" ", bestFullDna));

        }
    }
}

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
            char[] bestFullDna = Array.Empty<char>();
            int bestIndex = 0;
            int bestSum = 0;
            int bestSample = 0;
            int sample = 0;
            int sum = 0;
            string bestSubsiquence = "";

            while (sequenses != "Clone them!")
            {
                string arr = sequenses.Replace("!", "");
                string[] ones = arr.Split("0", StringSplitOptions.RemoveEmptyEntries).ToArray();
                char[] fullDna = arr.ToArray();
                sample++;
                sum = 0;
                int count = 0;

                foreach (var item in ones)
                {
                    sum += count;
                    if (item.Length > count)
                    {
                        count = item.Length;
                        bestSubsiquence = item;
                    }
                    int index = arr.IndexOf(bestSubsiquence);


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


                //for (int i = 0; i < arr.Length; i++)
                //{

                //    int count = 0;



                //    for (int j = i; j < arr.Length; j++)
                //    {
                //        if (arr[j] == 1)
                //        {
                //            count++;
                //            int index = i;

                //            if (count > bestCount ||
                //               (count == bestCount && index < bestIndex) ||
                //               (count == bestCount && index == bestIndex &&
                //               sum > bestSum))
                //            {

                //                bestCount = count;
                //                bestFullDna = fullDna;
                //                bestIndex = index;
                //                bestSum = sum;
                //                bestSample = sample;
                //            }
                //        }
                //        else
                //        {
                //            break;
                //        }
                //    }
                //}

                sequenses = Console.ReadLine();
            }
            Console.WriteLine($"Best DNA sample {bestSample} with sum: {sum}.");
            Console.WriteLine(string.Join(" ", bestFullDna));

        }
    }
}

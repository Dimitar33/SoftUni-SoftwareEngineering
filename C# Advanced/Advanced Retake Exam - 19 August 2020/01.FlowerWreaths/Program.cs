using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rosesOnput = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[] liliesInput = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            Stack<int> lilies = new Stack<int>();
            Queue<int> roses = new Queue<int>();

            int storedFlowers = 0;
            int wreaths = 0;

            for (int i = 0; i < rosesOnput.Length; i++)
            {
                roses.Enqueue(rosesOnput[i]);
            }

            for (int i = 0; i < liliesInput.Length; i++)
            {
                lilies.Push(liliesInput[i]);
            }

            while (lilies.Count > 0 && roses.Count > 0)
            {
                int curentRose = roses.Dequeue();
                int curentLilie = lilies.Pop();

                if (curentLilie + curentRose > 15)
                {
                    while (curentLilie + curentRose > 15)
                    {
                        curentLilie -= 2;
                    }
                }
                if (curentLilie + curentRose == 15)
                {
                    wreaths++;
                }
                else
                {
                    storedFlowers += curentLilie + curentRose;
                }
            }
            wreaths += storedFlowers / 15;

            if (wreaths > 4)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreaths} wreaths more!");
            }
        }
    }
}

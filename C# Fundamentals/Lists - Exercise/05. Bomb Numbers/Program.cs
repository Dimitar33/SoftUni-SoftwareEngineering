using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace _05._Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> field = Console.ReadLine().Split().Select(int.Parse).ToList();

            int[] bomb = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < field.Count; i++)
            {
                if (field[i] == bomb[0])
                {
                    int startIndex = i - bomb[1];
                    int endIndex = bomb[1] * 2 +1;

                    if (startIndex < 0)
                    {
                        startIndex = 0;
                    }
                    if (endIndex + startIndex > field.Count)
                    {
                        endIndex = field.Count - startIndex;
                    }

                    field.RemoveRange(startIndex, endIndex);

                    i -= endIndex;
                    if (i < 0)
                    {
                        i = 0;
                    }
                }
            }
            Console.WriteLine(field.Sum());
        }
    }
}

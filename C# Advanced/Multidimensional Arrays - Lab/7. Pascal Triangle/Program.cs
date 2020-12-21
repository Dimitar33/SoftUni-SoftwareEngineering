using System;

namespace _7._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            long[][] jaged = new long[n][];
            int row = 1;

            for (int y = 0; y < n; y++)
            {
                jaged[y] = new long[row];

                jaged[y][0] = 1;
                jaged[y][jaged[y].Length - 1] = 1;

                if (y > 1)
                {
                    for (int x = 1; x < row - 1; x++)
                    {
                        jaged[y][x] = jaged[y - 1][x] + jaged[y - 1][x - 1];
                    }

                }
                row++;

            }
            foreach (var item in jaged)
            {
                Console.WriteLine(string.Join(" ", item));
            }

        }
    }
}

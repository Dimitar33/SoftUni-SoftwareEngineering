using System;
using System.Linq;

namespace _8._Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] field = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int j = 0; j < n; j++)
                {
                    field[i, j] = nums[j];
                }
            }
            int[] bombs = Console.ReadLine().Split(new char[] { ' ', ',' }).Select(int.Parse).ToArray();

            for (int i = 0; i < bombs.Length - 1; i += 2)
            {
                int x = bombs[i];
                int y = bombs[i + 1];

                if (field[x, y] > 0)
                {
                    if (x - 1 >= 0 && y - 1 >= 0 && field[x - 1, y - 1] > 0)
                    {
                        field[x - 1, y - 1] -= field[x, y];
                    }
                    if (x + 1 < n && y - 1 >= 0 && field[x + 1, y - 1] > 0)
                    {
                        field[x + 1, y - 1] -= field[x, y];
                    }
                    if (y - 1 >= 0 && field[x, y - 1] > 0)
                    {
                        field[x, y - 1] -= field[x, y];
                    }
                    if (x - 1 >= 0 && y + 1 < n && field[x - 1, y + 1] > 0)
                    {
                        field[x - 1, y + 1] -= field[x, y];
                    }
                    if (x + 1 < n && y + 1 < n && field[x + 1, y + 1] > 0)
                    {
                        field[x + 1, y + 1] -= field[x, y];
                    }
                    if (y + 1 < n && field[x, y + 1] > 0)
                    {
                        field[x, y + 1] -= field[x, y];
                    }
                    if (x - 1 >= 0 && field[x - 1, y] > 0)
                    {
                        field[x - 1, y] -= field[x, y];
                    }
                    if (x + 1 < n && field[x + 1, y] > 0)
                    {
                        field[x + 1, y] -= field[x, y];
                    }

                    field[x, y] = 0;
                }
            }
            int sum = 0;
            int alive = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (field[i,j] > 0)
                    {
                        alive++;
                        sum += field[i, j];
                    }
                }
            }
            Console.WriteLine($"Alive cells: {alive}");
            Console.WriteLine($"Sum: {sum}");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(field[i,j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

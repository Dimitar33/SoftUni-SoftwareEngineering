using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double[][] jaged = new double[n][];

            for (int i = 0; i < n; i++)
            {
                int[] rols = Console.ReadLine().Split().Select(int.Parse).ToArray();
                jaged[i] = new double[rols.Length];

                for (int j = 0; j < rols.Length; j++)
                {
                    jaged[i][j] = rols[j];
                }
            }
            for (int i = 0; i < n - 1; i++)
            {
                if (jaged[i].Length == jaged[i + 1].Length)
                {
                    jaged[i] = jaged[i].Select(c => c * 2).ToArray();
                    jaged[i + 1] = jaged[i + 1].Select(c => c * 2).ToArray();
                }
                else
                {
                    jaged[i] = jaged[i].Select(c => c / 2).ToArray();
                    jaged[i + 1] = jaged[i + 1].Select(c => c / 2).ToArray();
                }
            }

            string[] cmd = Console.ReadLine().Split();

            while (cmd[0] != "End")
            {
                int x = int.Parse(cmd[1]);
                int y = int.Parse(cmd[2]);
                int value = int.Parse(cmd[3]);

                if (x >= 0 && x < jaged.Length && y >= 0 && y < jaged[x].Length)
                {
                    if (cmd[0] == "Add")
                    {
                        jaged[x][y] += value;
                    }
                    else
                    {
                        jaged[x][y] -= value;
                    }
                }
                cmd = Console.ReadLine().Split();
            }




            for (int i = 0; i < jaged.GetLength(0); i++)
            {
                for (int j = 0; j < jaged[i].Length; j++)
                {
                    Console.Write(jaged[i][j] + " ");
                }
                Console.WriteLine();
            }

        }

    }
}

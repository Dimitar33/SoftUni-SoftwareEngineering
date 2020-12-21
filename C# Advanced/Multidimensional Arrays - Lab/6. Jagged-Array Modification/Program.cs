using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[][] jaged = new int[n][];

            for (int row = 0; row < n; row++)
            {
                int[] data = Console.ReadLine().Split().Select(int.Parse).ToArray();
                jaged[row] = new int[data.Length];

                for (int i = 0; i < data.Length; i++)
                {
                    jaged[row][i] = data[i];
                }
            }
            string[] cmd = Console.ReadLine().Split();

            while (cmd[0] != "END")
            {
                int x = int.Parse(cmd[1]);
                int y = int.Parse(cmd[2]);
                int num = int.Parse(cmd[3]);
                if (!(x >= 0 && x < jaged.GetLength(0) && y >= 0 && y < jaged[x].Length))
                {
                    Console.WriteLine("Invalid coordinates");
                }
                else if (cmd[0] == "Add")
                {
                    jaged[x][y] += num;
                }
                else
                {
                    jaged[x][y] -= num;
                }
                cmd = Console.ReadLine().Split();
            }
            for (int rol = 0; rol < jaged.GetLength(0); rol++)
            {
                Console.WriteLine(string.Join(" ", jaged[rol]));

            }
        }
    }
}

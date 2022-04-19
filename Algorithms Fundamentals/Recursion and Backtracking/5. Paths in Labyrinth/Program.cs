using System;
using System.Collections.Generic;

namespace _5._Paths_in_Labyrinth
{
    class Program
    {
        private static char[,] lab;
        private static List<char> path = new List<char>();
        static void Main(string[] args)
        {
            int col = int.Parse(Console.ReadLine());
            int rol = int.Parse(Console.ReadLine());

            lab = new char[rol, col];

            for (int i = 0; i < lab.GetLength(0); i++)
            {
                var input = Console.ReadLine();

                for (int j = 0; j < lab.GetLength(1); j++)
                {
                    lab[i, j] = input[j];
                }
            }

            FindPaths(0, 0, 'S');
        }

        private static void FindPaths(int rol, int col, char direction)
        {
            if (rol + 1 > lab.GetLength(0) || col + 1 > lab.GetLength(1) || rol < 0 || col < 0)
            {
                return;
            }

            if (lab[rol, col] == '*' || lab[rol, col] == 'v')
            {
                return;
            }

            if (lab[rol, col] == 'e')
            {
                Console.WriteLine(string.Join("", path));
                path.RemoveAt(path.Count - 1);
                return;
            }

            lab[rol, col] = 'v';
            path.Add(direction);

            FindPaths(rol, col + 1, 'U');
            FindPaths(rol, col - 1, 'D');
            FindPaths(rol + 1, col, 'R');
            FindPaths(rol - 1, col, 'L');

            lab[rol, col] = '-';

            path.RemoveAt(path.Count - 1);

        }
    }
}

using System;

namespace _7._Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] board = new char[n, n];
            int count = 0;
            int max = 0;
            int x = 0;
            int y = 0;
            int removed = 0;

            for (int i = 0; i < n; i++)
            {
                string data = Console.ReadLine();

                for (int j = 0; j < n; j++)
                {
                    board[i, j] = data[j];
                }
            }
            do
            {

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        count = 0;

                        if (board[i, j] == 'K')
                        {
                            if (i + 1 < n && j + 2 < n && board[i + 1, j + 2] == 'K')
                            {
                                count++;
                            }
                            if (i + 2 < n && j + 1 < n && board[i + 2, j + 1] == 'K')
                            {
                                count++;
                            }
                            if (i - 1 >= 0 && j - 2 >= 0 && board[i - 1, j - 2] == 'K')
                            {
                                count++;
                            }
                            if (i - 2 >= 0 && j - 1 >= 0 && board[i - 2, j - 1] == 'K')
                            {
                                count++;
                            }
                            if (i - 2 >= 0 && j + 1 < n && board[i - 2, j + 1] == 'K')
                            {
                                count++;
                            }
                            if (i + 2 < n && j - 1 >= 0 && board[i + 2, j - 1] == 'K')
                            {
                                count++;
                            }
                            if (i - 1 >= 0 && j + 2 < n && board[i - 1, j + 2] == 'K')
                            {
                                count++;
                            }
                            if (i + 1 < n && j - 2 >= 0 && board[i + 1, j - 2] == 'K')
                            {
                                count++;
                            }
                            if (count > max)
                            {
                                max = count;
                                x = i;
                                y = j;

                            }
                        }
                    }
                }
                if (max > 0)
                {
                    board[x, y] = '0';
                    removed++;
                    max = 0;

                }
                else
                {
                    break;
                }

            } while (true);

            Console.WriteLine(removed);
        }
    }
}

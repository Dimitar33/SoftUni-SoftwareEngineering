using System;

namespace _02.Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int cmdCount = int.Parse(Console.ReadLine());

            char[,] track = new char[n, n];

            int col = 0;
            int rol = 0;


            for (int i = 0; i < n; i++)
            {
                char[] filing = Console.ReadLine().ToCharArray();

                for (int j = 0; j < n; j++)
                {
                    track[i, j] = filing[j];
                    if (filing[j] == 'f')
                    {
                        col = i;
                        rol = j;
                    }
                }
            }
            bool isFinish = false;


            for (int i = 0; i < cmdCount; i++)
            {
                string move = Console.ReadLine();

                if (isFinish)
                {
                    break;
                }

                if (move == "up")
                {
                    track[col, rol] = '-';
                    col--;

                    if (col < 0)
                    {
                        col = n - 1;
                    }

                    if (track[col, rol] == 'B')
                    {                       
                        col--;

                        if (col < 0)
                        {
                            col = n - 1;
                        }

                    }
                    if (track[col, rol] == 'T')
                    {
                        
                        col++;

                        if (col == n)
                        {
                            col = 0;
                        }

                    }

                    isFinish = Finish(track, col, rol);

                    track[col, rol] = 'f';
                }

                else if (move == "down")
                {
                    track[col, rol] = '-';
                    col++;

                    if (col == n)
                    {
                        col = 0;
                    }

                    if (track[col, rol] == 'B')
                    {
                        
                        col++;

                        if (col == n)
                        {
                            col = 0;
                        }

                    }
                    if (track[col, rol] == 'T')
                    {
                        
                        col--;

                        if (col < 0)
                        {
                            col = n - 1;
                        }

                    }

                    isFinish = Finish(track, col, rol);

                    track[col, rol] = 'f';
                }

                if (move == "left")
                {
                    track[col, rol] = '-';
                    rol--;

                    if (rol < 0)
                    {
                        rol = n - 1;
                    }

                    if (track[col, rol] == 'B')
                    {
                        
                        rol--;

                        if (rol < 0)
                        {
                            rol = n - 1;
                        }

                    }
                    if (track[col, rol] == 'T')
                    {
                        
                        rol++;

                        if (rol == n)
                        {
                            rol = 0;
                        }

                    }

                    isFinish = Finish(track, col, rol);

                    track[col, rol] = 'f';
                }

                else if (move == "right")
                {
                    track[col, rol] = '-';
                    rol++;

                    if (rol == n)
                    {
                        rol = 0;
                    }

                    if (track[col, rol] == 'B')
                    {
                      
                        rol++;

                        if (rol == n)
                        {
                            rol = 0;
                        }

                    }
                    if (track[col, rol] == 'T')
                    {
                      
                        rol--;

                        if (rol < 0)
                        {
                            rol = n - 1;
                        }

                    }

                    isFinish = Finish(track, col, rol);

                    track[col, rol] = 'f';
                }
            }

            if (isFinish)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }

            for (int j = 0; j < n; j++)
            {
                for (int k = 0; k < n; k++)
                {
                    Console.Write(track[j, k]);
                }
                Console.WriteLine();
            }
        }

        private static bool Finish(char[,] track, int col, int rol)
        {
            if (track[col, rol] == 'F')
            {
                return true;
            }
            return false;
        }

    }
}

using System;
using System.Linq;

namespace _02.Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] bakery = new char[n, n];
            int x = 0;
            int y = 0;
            int money = 0;
            bool isOut = false;
            int pilar1y = 0;
            int pilar1x = 0;
            int pilar2y = 0;
            int pilar2x = 0;
            int count = 0;

            for (int i = 0; i < n; i++)
            {
                char[] fill = Console.ReadLine().ToCharArray();

                for (int j = 0; j < n; j++)
                {
                    bakery[i, j] = fill[j];

                    if (fill[j] == 'S')
                    {
                        y = i;
                        x = j;
                    }
                    if (fill[j] == 'O')
                    {
                        if (count == 0)
                        {
                            pilar1y = i;
                            pilar1x = j;
                        }
                        else
                        {
                            pilar2y = i;
                            pilar2x = j;
                        }
                    }
                }
            }

            string move = Console.ReadLine();

            while (money < 50 && isOut == false)
            {           

                if (move == "left" && x - 1 >= 0)
                {

                    if (bakery[y, x - 1] == 'O')
                    {
                        bakery[y, x - 1] = '-';
                        bakery[x, y] = '-';

                        if (y == pilar1y && x - 1 == pilar1x)
                        {
                            y = pilar2y;
                            x = pilar2x;
                        }
                        else
                        {
                            y = pilar1y;
                            x = pilar1x;
                        }
                        bakery[y, x] = 'S';
                    }
                    else if (bakery[y, x - 1] == '-')
                    {
                        bakery[y, x - 1] = 'S';
                        bakery[y, x] = '-';
                        x--;
                    }
                    else
                    {
                        money += bakery[y, x - 1] - '0';
                        bakery[y, x - 1] = 'S';
                        bakery[y, x] = '-';
                        x--;
                    }
                }
                else if (move == "right" && x + 1 < bakery.GetLength(1))
                {
                    if (bakery[y, x + 1] == 'O')
                    {
                        bakery[y, x + 1] = '-';
                        bakery[y, x] = '-';

                        if (y == pilar1y && x + 1 == pilar1x)
                        {
                            y = pilar2y;
                            x = pilar2x;
                        }
                        else
                        {
                            y = pilar1y;
                            x = pilar1x;
                        }
                        bakery[y, x] = 'S';
                    }
                    else if (bakery[y, x + 1] == '-')
                    {
                        bakery[y, x + 1] = 'S';
                        bakery[y, x] = '-';
                        x++;
                    }
                    else
                    {
                        money += bakery[y, x + 1] - '0';
                        bakery[y, x + 1] = 'S';
                        bakery[y, x] = '-';
                        x++;
                    }
                }
                else if (move == "up" && y - 1 >= 0)
                {
                    if (bakery[y - 1, x] == 'O')
                    {
                        bakery[y - 1, x] = '-';
                        bakery[y, x] = '-';

                        if (y - 1 == pilar1y && x == pilar1x)
                        {
                            y = pilar2y;
                            x = pilar2x;
                        }
                        else
                        {
                            y = pilar1y;
                            x = pilar1x;
                        }
                        bakery[y, x] = 'S';
                    }
                    else if (bakery[y - 1, x] == '-')
                    {
                        bakery[y - 1, x] = 'S';
                        bakery[y, x] = '-';
                        y--;
                    }
                    else
                    {
                        money += bakery[y - 1, x] - '0';
                        bakery[y - 1, x] = 'S';
                        bakery[y, x] = '-';
                        y--;
                    }
                }
                else if (move == "down" && y + 1 < bakery.GetLength(0))
                {
                    if (bakery[y + 1, x] == 'O')
                    {
                        bakery[y + 1, x] = '-';
                        bakery[y, x] = '-';

                        if (y + 1 == pilar1y && x == pilar1x)
                        {
                            y = pilar2y;
                            x = pilar2x;
                        }
                        else
                        {
                            y = pilar1y;
                            x = pilar1x;
                        }
                        bakery[y, x] = 'S';
                    }
                    else if (bakery[y + 1, x] == '-')
                    {
                        bakery[y + 1, x] = 'S';
                        bakery[y, x] = '-';
                        y++;
                    }
                    else
                    {
                        money += bakery[y + 1, x] - '0';
                        bakery[y + 1, x] = 'S';
                        bakery[y, x] = '-';
                        y++;
                    }
                }
                else
                {

                    isOut = true;
                    break;
                }
              
                move = Console.ReadLine();

            }

            if (isOut)
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
                Console.WriteLine($"Money: {money}");
                bakery[y, x] = '-';
            }
            else
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
                Console.WriteLine($"Money: {money}");
            }

            for (int i = 0; i < bakery.GetLength(0); i++)
            {
                for (int j = 0; j < bakery.GetLength(1); j++)
                {
                    Console.Write(bakery[i, j]);
                }
                Console.WriteLine();
            }
        }

    }
}

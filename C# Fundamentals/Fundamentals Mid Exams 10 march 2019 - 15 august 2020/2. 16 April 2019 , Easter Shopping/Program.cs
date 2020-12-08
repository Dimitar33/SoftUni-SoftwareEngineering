using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._16_April_2019___Easter_Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> shopsList = Console.ReadLine().Split().ToList();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] cmd = Console.ReadLine().Split();

                switch (cmd[0])
                {

                    case "Include":

                        shopsList.Add(cmd[1]);

                        break;
                    case "Visit":
                        int number = int.Parse(cmd[2]);

                        if (number > shopsList.Count)
                        {
                            break;
                        }

                        else if (cmd[1] == "first")
                        {
                            shopsList.RemoveRange(0, number);
                        }
                        else
                        {
                            shopsList.RemoveRange(shopsList.Count - number, number);
                        }
                        break;
                    case "Prefer":
                        int index1 = int.Parse(cmd[1]);
                        int index2 = int.Parse(cmd[2]);

                        if (index1 >= 0 && index1 < shopsList.Count && index2 >= 0 && index2 < shopsList.Count)
                        {
                            string temp = shopsList[index1];
                            shopsList[index1] = shopsList[index2];
                            shopsList[index2] = temp;
                        }
                        else
                        {
                            break;
                        }

                        break;
                    case "Place":

                        index2 = int.Parse(cmd[2]);

                        if (index2 >= 0 && index2 < shopsList.Count)
                        {
                            shopsList.Insert(index2 + 1, cmd[1]);
                        }
                        else
                        {
                            break;
                        }


                        break;

                    default:
                        break;
                }
            }

            Console.WriteLine("Shops left:");
            Console.WriteLine(string.Join(" ", shopsList));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace _1._29_February_2020_Group_2_Shopping_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> products = Console.ReadLine().Split("!", StringSplitOptions.RemoveEmptyEntries).ToList();
            string go = Console.ReadLine();
                

            while (go != "Go Shopping!")
            {

                string[] cmd = go.Split();

                string item = cmd[1];
                switch (cmd[0])
                {
                    case "Urgent":

                        if (products.Contains(item))
                        {
                            break;
                        }
                        else
                        {
                            products.Insert(0, item);
                        }
                        break;
                    case "Unnecessary":

                        if (products.Contains(item))
                        {
                            products.Remove(item);
                        }
                        else
                        {
                            break;
                        }
                        break;
                    case "Correct":

                        if (products.Contains(item))
                        {
                            int index = products.IndexOf(item);
                            products.Remove(item);
                            products.Insert(index, cmd[2]);
                        }
                        else
                        {
                            break;
                        }
                        break;
                    case "Rearrange":

                        if (products.Contains(item))
                        {
                            products.Remove(item);
                            products.Add(item);
                        }
                        else
                        {
                            break;
                        }

                        break;


                    default:
                        break;

                }

                go = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", products));
        }
    }
}

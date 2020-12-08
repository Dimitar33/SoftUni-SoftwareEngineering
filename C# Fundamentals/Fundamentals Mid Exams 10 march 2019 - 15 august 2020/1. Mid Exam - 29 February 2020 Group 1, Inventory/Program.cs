using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _1._Mid_Exam___29_February_2020_Group_1__Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List <string> items = Console.ReadLine().Split(", ").ToList();
            string[] cmd = Console.ReadLine().Split(new string[]
            { " - ", ":" }, StringSplitOptions.RemoveEmptyEntries);

            while (cmd[0] != "Craft!")
            {
                switch (cmd[0])
                {

                    case "Collect":

                        if (items.Contains(cmd[1]))
                        {
                            break;
                        }
                        else
                        {
                            items.Add(cmd[1]);
                        }
                        break;
                    case "Drop":

                        if (items.Contains(cmd[1]))
                        {
                            items.Remove(cmd[1]);
                        }
                        else
                        {
                            break;
                        }
                        break;
                    case "Combine Items":

                        if (items.Contains(cmd[1]))
                        {
                            int index = items.IndexOf(cmd[1]);
                            items.Insert(index + 1, cmd[2]);
                        }
                        else
                        {
                            break;
                        }
                        break;
                    case "Renew":

                        if (items.Contains(cmd[1]))
                        {                           
                            items.Remove(cmd[1]);
                            items.Add(cmd[1]);
                        }
                        else
                        {
                            break;
                        }
                        break;

                    default:
                        break;

                }
                cmd = Console.ReadLine().Split(new string[]
            { " - ", ":" }, StringSplitOptions.RemoveEmptyEntries);
            }
            Console.WriteLine(string.Join(", ", items));
        }
    }
}

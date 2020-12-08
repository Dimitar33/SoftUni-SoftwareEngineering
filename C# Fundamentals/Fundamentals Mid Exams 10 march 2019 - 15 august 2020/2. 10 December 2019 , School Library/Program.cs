using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _2._10_December_2019___School_Library
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> library = Console.ReadLine().Split("&").ToList();

            string[] cmd = Console.ReadLine().Split(" | ");

            while (cmd[0] != "Done")
            {
               
                switch (cmd[0])
                {
                    case "Add Book":                       

                        if (library.Contains(cmd[1]))
                        {
                            break;
                        }
                        else
                        {
                            library.Insert(0, cmd[1]);
                        }

                        break;
                    case "Take Book":

                        if (library.Contains(cmd[1]))
                        {
                            library.Remove(cmd[1]);
                        }
                        else
                        {
                            break;
                        }

                        break;
                    case "Swap Books":

                        if (library.Contains(cmd[1]) && library.Contains(cmd[2]))
                        {
                           int index1 = library.IndexOf(cmd[1]);
                           int index2 = library.IndexOf(cmd[2]);

                            library[index1] = cmd[2];
                            library[index2] = cmd[1];
                        }
                        else
                        {
                            break;
                        }

                        break;
                    case "Insert Book":

                        library.Add(cmd[1]);

                        break;
                    case "Check Book":

                        int index = int.Parse(cmd[1]);
                        if (index < 0 || index > library.Count -1)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine(library[index]);
                        }

                        break;


                    default:
                        break;
                }
                cmd = Console.ReadLine().Split(" | ");
            }
            Console.WriteLine(string.Join(", ", library));
        }
    }
}

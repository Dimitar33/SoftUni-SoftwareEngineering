using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._10_March_2019_Group_1__Last_Stop
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> collection = Console.ReadLine().Split().ToList();

            string[] cmd = Console.ReadLine().Split();

            while (cmd[0] != "END")
            {              
                switch (cmd[0])
                {

                    case "Change":

                        if (collection.Contains(cmd[1]))
                        {
                            int index = collection.IndexOf(cmd[1]);

                            collection.Insert(index, cmd[2]);
                            collection.Remove(cmd[1]);
                        }

                        break;
                    case "Hide":

                        if (collection.Contains(cmd[1]))
                        {
                            collection.Remove(cmd[1]);
                        }

                        break;
                    case "Switch":

                        if (collection.Contains(cmd[1]) && collection.Contains(cmd[2]))
                        {
                            int index1 = collection.IndexOf(cmd[1]);
                            int index2 = collection.IndexOf(cmd[2]);

                            string temp = collection[index1];
                            collection[index1] = collection[index2];
                            collection[index2] = temp;
                        }

                        break;
                    case "Insert":

                        int num = int.Parse(cmd[1]);
                        if (num >= 0 && num < collection.Count)
                        {
                            collection.Insert(num + 1, cmd[2]);
                        }

                        break;
                    case "Reverse":

                       collection.Reverse();

                        break;

                    default:
                        break;
                }
                cmd = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(" ", collection));
        }
    }
}

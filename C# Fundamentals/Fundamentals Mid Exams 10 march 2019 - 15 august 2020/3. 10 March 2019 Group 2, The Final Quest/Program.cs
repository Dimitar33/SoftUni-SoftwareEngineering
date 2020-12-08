using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._10_March_2019_Group_2__The_Final_Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine().Split().ToList();

            string[] cmd = Console.ReadLine().Split();

            while (cmd[0] != "Stop")
            {
                switch (cmd[0])
                {
                    case "Delete":
                        int index = int.Parse(cmd[1]);

                        if (index >= 0 && index < words.Count - 1)
                        {
                            words.RemoveAt(index + 1);
                        }

                        break;
                    case "Swap":

                        if (words.Contains(cmd[1]) && words.Contains(cmd[2]))
                        {
                            int index1 = words.IndexOf(cmd[1]);
                            int index2 = words.IndexOf(cmd[2]);
                            words[index1] = cmd[2];
                            words[index2] = cmd[1];
                        }

                        break;
                    case "Put":

                        index = int.Parse(cmd[2]) - 1;

                        if (index > 0 && index <= words.Count)
                        {
                            words.Insert(index , cmd[1]);
                        }

                        break;
                    case "Sort":

                       words = words.OrderByDescending(c => c).ToList();

                        break;
                    case "Replace":

                        if (words.Contains(cmd[2]))
                        {
                            index = words.IndexOf(cmd[2]);
                            words.Insert(index, cmd[1]);
                            words.Remove(cmd[2]);
                        }

                        break;

                    default:
                        break;
                }
                cmd = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(" ", words));
        }
    }
}

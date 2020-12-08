using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;

namespace _08._Anonymous_Threat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> str = Console.ReadLine().Split().ToList();

            string[] cmd = Console.ReadLine().Split();


            while (cmd[0] != "3:1")
            {
                int start = int.Parse(cmd[1]);
                int end = int.Parse(cmd[2]);

                if (start < 0)
                {
                    start = 0;
                }
                

                if (cmd[0] == "merge")
                {

                    if (end >= str.Count)
                    {
                        end = str.Count - 1;
                    }
                    if (start >= end)
                    {
                        cmd = Console.ReadLine().Split();
                        continue;
                    }
                    string merge = "";

                    for (int i = start; i <= end; i++)
                    {
                        merge += str[i];
                    }
                    str.RemoveRange(start, end - start + 1);
                    str.Insert(start, merge);

                }
                else if (cmd[0] == "divide")
                {
                    string word = str[start];
                    str.RemoveAt(start);
                    int letters = word.Length / end;
                    List<string> scrap = new List<string>();

                    for (int i = 0; i < end; i++)
                    {
                        if (i == end - 1)
                        {
                            scrap.Add(word.Substring(i * letters));
                        }
                        else
                        {
                            scrap.Add(word.Substring(i * letters, letters));

                        }
                    }
                    str.InsertRange(start, scrap);

                }

                cmd = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(" ", str));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Mid_Exam_Retake___07_April_2020__Moving_Target
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> range = Console.ReadLine().Split().Select(int.Parse).ToList();

            string[] cmd = Console.ReadLine().Split();

            while (cmd[0] != "End")
            {
                int index = int.Parse(cmd[1]);
                int pow = int.Parse(cmd[2]);

                if (cmd[0] == "Shoot")
                {
                    if (index < 0 || index >= range.Count)
                    {
                        cmd = Console.ReadLine().Split();
                        continue;
                    }
                    else
                    {
                        range[index] -= pow;
                        if (range[index] <= 0)
                        {
                            range.Remove(range[index]);
                        }
                    }
                }
                else if (cmd[0] == "Add")
                {
                    if (index < 0 || index >= range.Count)
                    {
                        Console.WriteLine($"Invalid placement!");
                        cmd = Console.ReadLine().Split();
                        continue;
                    }
                    else
                    {
                        range.Insert(index, pow);
                    }
                }
                else
                {
                    if ((index - pow) < 0 || (index + pow) >= range.Count)
                    {
                        Console.WriteLine("Strike missed!");
                        cmd = Console.ReadLine().Split();
                        continue;
                    }
                    else
                    {
                        range.RemoveRange((index - pow), (pow * 2 + 1));
                    }

                }
                cmd = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join("|", range));
        }
    }
}

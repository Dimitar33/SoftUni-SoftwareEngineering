using System;
using System.Collections.Generic;
using System.Linq;

namespace Sugar_Cubes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();

            string[] cmd = Console.ReadLine().Split();

            while (cmd[0] != "Mort")
            {
                int value = int.Parse(cmd[1]);

                switch (cmd[0])
                {
                    case "Add":

                        nums.Add(value);

                        break;
                    case "Remove":

                        nums.Remove(value);

                        break;
                    case "Replace":

                        int index = nums.IndexOf(value);
                        nums[index] = int.Parse(cmd[2]);

                        break;
                    case "Collapse":

                        nums = nums.Where(c => c >= value).ToList();

                        break;

                    default:
                        break;
                }
                cmd = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(" ", nums));
        }
    }
}

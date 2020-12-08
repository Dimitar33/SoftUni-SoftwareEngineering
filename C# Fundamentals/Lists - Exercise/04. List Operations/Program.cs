using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._List_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();

            string[] cmd = Console.ReadLine().Split();

            while (cmd[0] != "End")
            {
                switch (cmd[0])
                {
                    case "Add":
                        nums.Add(int.Parse(cmd[1]));
                        break;

                    case "Insert":
                        if (int.Parse(cmd[2]) < 0 || int.Parse(cmd[2]) > nums.Count)
                        {
                            Console.WriteLine("Invalid index");
                        }
                        else
                        {

                            nums.Insert(int.Parse(cmd[2]), int.Parse(cmd[1]));
                        }
                        break;

                    case "Remove":
                        if (int.Parse(cmd[1]) < 0 || int.Parse(cmd[1]) > nums.Count)
                        {
                            Console.WriteLine("Invalid index");
                        }
                        else
                        {
                            nums.RemoveAt(int.Parse(cmd[1]));
                        }
                        break;

                    case "Shift":

                        if (cmd[1] == "left")
                        {
                            for (int j = 0; j < int.Parse(cmd[2]); j++)
                            {

                                int temp = nums[0];
                                for (int i = 0; i < nums.Count - 1; i++)
                                {
                                    nums[i] = nums[i + 1];
                                }
                                nums[nums.Count - 1] = temp;
                            }
                        }
                        else
                        {
                            for (int j = 0; j < int.Parse(cmd[2]); j++)
                            {
                                int temp = nums[nums.Count - 1];
                                for (int i = nums.Count - 1; i > 0; i--)
                                {
                                    nums[i] = nums[i - 1];
                                }
                                nums[0] = temp;
                            }
                        }
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

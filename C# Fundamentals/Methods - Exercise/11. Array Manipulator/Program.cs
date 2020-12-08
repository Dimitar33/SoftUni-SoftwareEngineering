using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _11._Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string[] cmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (cmd[0] != "end")
            {
                switch (cmd[0])
                {
                    case "exchange":

                        if (int.Parse(cmd[1]) >= nums.Length || int.Parse(cmd[1]) < 0)
                        {
                            Console.WriteLine("Invalid index");
                            break;
                        }

                        nums = Exchange(int.Parse(cmd[1]), nums);

                        break;
                    case "max":

                        Max(cmd[1], nums);

                        break;
                    case "min":

                        Min(cmd[1], nums);

                        break;
                    case "first":

                        First(int.Parse(cmd[1]), cmd[2], nums);

                        break;
                    case "last":

                        Last(int.Parse(cmd[1]), cmd[2], nums);

                        break;

                    default:
                        break;
                }


                cmd = Console.ReadLine().Split();
            }
            Console.WriteLine($"[{string.Join(", ", nums)}]");
        }

        private static int[] Exchange(int number, int[] nums)
        {

            int[] first = nums.Take(number + 1).ToArray();
            int[] second = nums.Skip(number + 1).ToArray();
            nums = second.Concat(first).ToArray();

            return nums;
        }

        private static void Max(string evenOdd, int[] nums)
        {
            int count = 0;
            int max = int.MinValue;
            if (evenOdd == "even")
            {

                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] % 2 == 0 && nums[i] >= max)
                    {
                        max = nums[i];
                        count = i;
                    }
                }

            }
            else
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] % 2 != 0 && nums[i] >= max)
                    {
                        max = nums[i];
                        count = i;
                    }
                }
            }
            if (max == int.MinValue)
            {
                Console.WriteLine("No matches");
            }
            else
            {

                Console.WriteLine(count);
            }
            return;
        }

        private static void Min(string evenOdd, int[] nums)
        {
            int min = int.MaxValue;
            int count = 0;
            if (evenOdd == "even")
            {

                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] % 2 == 0 && nums[i] <= min)
                    {
                        min = nums[i];
                        count = i;
                    }
                }
            }
            else
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] % 2 != 0 && nums[i] <= min)
                    {
                        min = nums[i];
                        count = i;
                    }
                }
            }
            if (min == int.MaxValue)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(count);
            }
            return;
        }

        private static void First(int number, string evenOdd, int[] nums)
        {
            if (number > nums.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            if (evenOdd == "even")
            {
                int count = 0;

                List<int> even = new List<int>();

                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] % 2 == 0)
                    {
                        count++;
                        even.Add(nums[i]);
                        if (count == number)
                        {
                            break;
                        }
                    }
                }
                Console.WriteLine($"[{string.Join(", ", even)}]");
            }
            else
            {
                if (number > nums.Length)
                {
                    Console.WriteLine("Invalid count");
                    return;
                }
                int count = 0;

                List<int> odd = new List<int>();

                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] % 2 != 0)
                    {
                        odd.Add(nums[i]);
                        count++;
                        if (count == number)
                        {
                            break;
                        }
                    }
                }
                Console.WriteLine($"[{string.Join(", ", odd)}]");
            }
        }

        private static void Last(int number, string evenOdd, int[] nums)
        {
            int[] reverse = nums.Reverse().ToArray();

            if (number > reverse.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            if (evenOdd == "even")
            {
                int count = 0;

                List<int> even = new List<int>();

                for (int i = 0; i < reverse.Length; i++)
                {
                    if (reverse[i] % 2 == 0)
                    {
                        count++;
                        even.Add(reverse[i]);
                        if (count == number)
                        {
                            break;
                        }
                    }
                }
                even.Reverse();
                Console.WriteLine($"[{string.Join(", ", even)}]");
                return;
            }
            else
            {
                if (number > reverse.Length)
                {
                    Console.WriteLine("Invalid count");
                    return;
                }
                int count = 0;

                List<int> odd = new List<int>();

                for (int i = 0; i < reverse.Length; i++)
                {
                    if (reverse[i] % 2 != 0)
                    {
                        odd.Add(reverse[i]);
                        count++;
                        if (count == number)
                        {
                            break;
                        }
                    }
                }
                odd.Reverse();
                Console.WriteLine($"[{string.Join(", ", odd)}]");
                return;
            }
        }
    }
}

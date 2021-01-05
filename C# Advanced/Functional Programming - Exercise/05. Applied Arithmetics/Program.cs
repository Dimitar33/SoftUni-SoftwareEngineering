using System;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string cmd = Console.ReadLine();

            

            while (cmd != "end")
            {
                nums = Calc(cmd, nums);
                cmd = Console.ReadLine();
            }

            
        }


        static int[] Calc(string cmd, int[] nums )
        {



            switch (cmd)
            {
                case "add":

                    nums = nums.Select(c => c + 1).ToArray();

                    break;
                case "multiply":

                    nums = nums.Select(c => c * 2).ToArray();

                    break;
                case "subtract":

                    nums = nums.Select(c => c - 1).ToArray();

                    break;
                case "print":

                    Console.WriteLine(string.Join(" ", nums));

                    break;

                default:
                    break;
            }

            return nums;
        }
    }
}

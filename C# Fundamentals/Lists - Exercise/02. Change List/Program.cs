using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            
            string[] cmd = Console.ReadLine().Split();


            while (cmd[0] != "end")
            {

                if (cmd[0] == "Delete")
                {
                    nums.RemoveAll(c => c == int.Parse(cmd[1]));
                }
                else
                {
                    nums.Insert(int.Parse(cmd[2]), int.Parse(cmd[1]));
                }
                cmd = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(" " , nums));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Append_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> str = Console.ReadLine().Split("|").ToList();

            str.Reverse();

            string asd = string.Join(" ", str);

            string[] dsa = asd.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            

            Console.WriteLine(string.Join(" " , dsa));
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine().Split().ToList();
            string name = "";          
            
            name = names.First(c =>
            {
                bool isTrue = false;
                int sum = 0;

                foreach (var item in c)
                {
                    sum += item;
                }

                if (sum >= n)
                {
                    isTrue = true;
                    return isTrue;
                }
                
                return isTrue;
            }).ToString();

            Console.WriteLine(name);

        }
    }
}

using System;
using System.Linq;

namespace _07._Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

           

            Console.WriteLine(string.Join(Environment.NewLine, Console.ReadLine().Split().Where(c => c.Length <= n).ToArray()));
        }
    }
}

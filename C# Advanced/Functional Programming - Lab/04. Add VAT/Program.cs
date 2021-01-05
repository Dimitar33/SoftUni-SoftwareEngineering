using System;
using System.Linq;

namespace _04._Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {

            Func<string, double> vat = c => double.Parse(c) * 1.2;

            Console.WriteLine(string.Join(Environment.NewLine, Console.ReadLine().Split(", ").Select(vat).Select(c => $"{c:f2}").ToArray()));

            
        }
    }
}

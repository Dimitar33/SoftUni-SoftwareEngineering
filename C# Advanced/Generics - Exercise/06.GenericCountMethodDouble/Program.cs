using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.GenericCountMethodDouble
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<double> list = new List<double>();

            for (int i = 0; i < n; i++)
            {
                double text = double.Parse(Console.ReadLine());

                list.Add(text);
            }

            Box<double> txt = new Box<double>(list);

            double subject = double.Parse(Console.ReadLine());

            Console.WriteLine(Compare(txt.items, subject));
            
        }

        public static int Compare<T>(List<T> list, T item) where T : IComparable
        {
            int count = 0;

            foreach (var i in list)
            {
                if (i.CompareTo(item) == 1)
                {
                    count++;
                }
            }
            return count;
        }
    }
}

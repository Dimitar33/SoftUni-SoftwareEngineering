using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.GenericCountMethodString
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> list = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string text = Console.ReadLine();

                list.Add(text);
            }

            Box<string> txt = new Box<string>(list);

            string subject = Console.ReadLine();

            Console.WriteLine(txt.Compare(subject));

        }


    }
}

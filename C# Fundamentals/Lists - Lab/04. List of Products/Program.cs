using System;
using System.Collections.Generic;

namespace _04._List_of_Products
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            List<string> items = new List<string>();

            for (int i = 0; i < num; i++)
            {
                string product = Console.ReadLine();

                items.Add (product);                
            }
            items.Sort();
            int count = 0;

            for (int i = 0; i < num; i++)
            {
                count++;
                Console.WriteLine($"{count}.{items[i]}");
            }

           
        }
    }
}

﻿using System;

namespace _01.GenericBoxOfString
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string text = Console.ReadLine();

                Box<string> box = new Box<string>(text);

                Console.WriteLine(box.ToString());
            }
        }
    }
}

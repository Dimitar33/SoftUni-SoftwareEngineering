using System;

namespace _3._Characters_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            char a = char.Parse(Console.ReadLine());
            char b = char.Parse(Console.ReadLine());

            charsBetween(a, b);
        }

        private static void charsBetween(char a, char b)
        {
            char smalest = a;
            char biggest = b;

            if (a > b)
            {
                smalest = b;
                biggest = a;
            }
            int lenght = biggest - smalest;
            

            for (int i = 1; i < lenght; i++)
            {
                Console.Write(((char)(i + smalest)) + " ");
            }
        }
    }
}

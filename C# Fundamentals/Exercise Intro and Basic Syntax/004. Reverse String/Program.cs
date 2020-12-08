using System;

namespace _004._Reverse_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string inpuit = Console.ReadLine();
            string reverse = string.Empty;

            for (int i = inpuit.Length - 1; i >= 0; i--)
            {
                reverse += inpuit[i];
            }
            Console.WriteLine(reverse);
        }
    }
}

using System;
using System.Linq;

namespace _9._Palindrome_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            string n = Console.ReadLine();

           poalindromeOrNot(n);

        }

        private static void poalindromeOrNot(string n)
        {
            

            while (n != "END")
            {
                int num = int.Parse(n);
                int reverce = 0;
                int temp = num;

                while (num > 0)
                {
                    
                    reverce = reverce * 10 + num % 10;
                    num /= 10;

                }
                if (reverce == temp)
                {
                    Console.WriteLine("true");
                    n = Console.ReadLine();
                    
                }
                else
                {
                    Console.WriteLine("false");
                    n = Console.ReadLine();
                    
                }
                
            }
            

        }
    }
}

using System;

namespace _05._Multiplication_Sign
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            int n3 = int.Parse(Console.ReadLine());

            int count =0 ;

            if (n1 == 0 || n2 == 0 || n3 == 0)
            {
                Console.WriteLine("zero");
                Environment.Exit(0);
            }
            if (n1 < 0)
            {
                count++;
            }
            if (n2 < 0)
            {
                count++;
            }
            if (n3 < 0)
            {
                count++;
            }
            if (count % 2 == 0)
            {
                Console.WriteLine("positive");
            }
            else
            {
                Console.WriteLine("negative");
            }

        }
    }
}

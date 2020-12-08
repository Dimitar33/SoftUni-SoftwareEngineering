using System;

namespace _01._Data_Types
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string n = (Console.ReadLine());

            int num = 0 ;
            double duble;
            string str;

            if (input == "int")
            {
                num = int.Parse(n);
                num *= 2;
                Console.WriteLine(num);
            }
            else if (input == "real")
            {
                duble = double.Parse(n);
                duble *= 1.5;
                Console.WriteLine($"{duble:f2}");
            }
            else 
            {
                Console.WriteLine($"${n}$");
            }

            
        }
    }
}

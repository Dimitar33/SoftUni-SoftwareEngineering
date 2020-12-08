using System;
using System.ComponentModel;

namespace _3._Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string operation = Console.ReadLine();
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());


            
            
            
            

            if (operation == "multiply")
            {
                multiply(num1, num2);
            }
            else if (operation == "divide")
            {
                Divide(num1, num2);
            }
            else if (operation == "add")
            {
                Add(num1, num2);
            }
            else if (operation == "sustract")
            {
                sunsract(num1, num2);
            }
        }

        private static void multiply(int num1, int num2)
        {
            Console.WriteLine($"{num1 * num2}");
        }

        private static void Add(int num1, int num2)
        {
            Console.WriteLine($"{num1 + num2}");
        }

        private static void Divide(int num1, int num2)
        {
            Console.WriteLine($"{num1 / num2}");
        }

        private static void sunsract(int num1, int num2)
        {
            Console.WriteLine($"{num1 - num2}");
        }
    }
}

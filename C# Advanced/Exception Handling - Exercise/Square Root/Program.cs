using System;

namespace Square_Root
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                int n = int.Parse(Console.ReadLine());
                Console.WriteLine(Math.Sqrt(n));

            }
            catch (Exception)
            {

                Console.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}

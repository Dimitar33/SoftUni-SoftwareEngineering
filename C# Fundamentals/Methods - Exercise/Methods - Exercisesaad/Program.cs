using System;

namespace Methods___Exercisesaad
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            int n3 = int.Parse(Console.ReadLine());

            int result = smallestNum(n1, n2, n3);

            Console.WriteLine(smallestNum(n1,n2,n3));
        }

        private static int smallestNum(int n1, int n2, int n3)
        {
            int smallest = Math.Min(Math.Min(n1, n2), n3);

            return smallest;
        }
    }
}

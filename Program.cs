using System;

namespace _001._Sort_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            int n3 = int.Parse(Console.ReadLine());
            
            int big = 0;
            int mid = 0;
            int low = 0;

            big = Math.Max(Math.Max(n1, n2), n3);
            low = Math.Min(Math.Min(n1, n2), n3);
            mid = (n1 + n2 + n3) - (big + low);

            Console.WriteLine(big);
            Console.WriteLine(mid);
            Console.WriteLine(low);
        }
    }
}

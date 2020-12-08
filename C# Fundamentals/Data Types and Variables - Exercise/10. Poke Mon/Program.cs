using System;
using System.Threading;

namespace _10._Poke_Mon
{
    class Program
    {
        static void Main(string[] args)
        {
            int pokePow = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int exhaustion = int.Parse(Console.ReadLine());
            int count = 0;
            int powOriginal = pokePow;

            while (pokePow >= distance)
            {
                pokePow -= distance;
                if (pokePow == powOriginal/2 && exhaustion != 0)
                {
                    pokePow /= exhaustion;
                }
                count++;
            }
            Console.WriteLine(pokePow);
            Console.WriteLine(count);
        }
    }
}

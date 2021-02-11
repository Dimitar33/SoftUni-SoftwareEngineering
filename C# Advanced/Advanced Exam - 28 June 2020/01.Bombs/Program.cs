using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bombEfectsInput = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[] bombCasingInput = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            Queue<int> efects = new Queue<int>();
            Stack<int> casings = new Stack<int>();

            int daturaBombs = 0;
            int cherryBombs = 0;
            int smokeDecoyBombs = 0;
            bool pouchFull = false;

            for (int i = 0; i < bombEfectsInput.Length; i++)
            {
                efects.Enqueue(bombEfectsInput[i]);
            }
            for (int i = 0; i < bombCasingInput.Length; i++)
            {
                casings.Push(bombCasingInput[i]);
            }

            while (efects.Count > 0 && casings.Count > 0)
            {
                int curentEfect = efects.Dequeue();
                int curentCasing = casings.Pop();

                while (curentCasing + curentEfect != 40 && curentCasing + curentEfect != 60 && curentCasing + curentEfect != 120)
                {
                    curentCasing -= 5;
                }

                if (curentCasing + curentEfect == 40)
                {
                    daturaBombs++;
                }
                else if (curentCasing + curentEfect == 60)
                {
                    cherryBombs++;
                }
                else if (curentCasing + curentEfect == 120)
                {
                    smokeDecoyBombs++;
                }

                if (cherryBombs > 2 && smokeDecoyBombs > 2 && daturaBombs > 2)
                {
                    pouchFull = true;
                    break;
                }
            }

            if (pouchFull)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }
            if (efects.Count == 0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", efects)}");
            }
            if (casings.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", casings)}");
            }

            Console.WriteLine($"Cherry Bombs: {cherryBombs}");
            Console.WriteLine($"Datura Bombs: {daturaBombs}");
            Console.WriteLine($"Smoke Decoy Bombs: {smokeDecoyBombs}");
        }
    }
}

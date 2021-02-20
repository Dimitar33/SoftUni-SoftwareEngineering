using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._The_Fight_for_Gondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<int> plates = Console.ReadLine().Split().Select(int.Parse).ToList();
            int counter = 0;

           
            Stack<int> orcs = new Stack<int>();


            for (int i = 0; i < n; i++)
            {
                int[] orcsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
                counter++;

                if (counter % 3 == 0)
                {
                    int reinforcements = int.Parse(Console.ReadLine());
                    plates.Add(reinforcements);
                }

                if (plates.Count == 0)
                {
                    break;
                }

                for (int j = 0; j < orcsInput.Length; j++)
                {
                    orcs.Push(orcsInput[j]);
                }

                int curentPlate = plates.First();
                             
                while (curentPlate > 0)
                {
                    int curentOrc = orcs.Pop();

                    if (curentOrc <= curentPlate)
                    {
                        curentPlate -= curentOrc;
                    }
                    else
                    {
                        curentOrc -= curentPlate;
                        orcs.Push(curentOrc);
                        break;
                    }
                }
            }

            if (plates.Count > 0)
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
            else
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");

                if (orcs.Count > 0)
                {
                    Console.WriteLine($"Orcs left: {string.Join(", ", orcs)}");
                }
            }
        }
    }
}

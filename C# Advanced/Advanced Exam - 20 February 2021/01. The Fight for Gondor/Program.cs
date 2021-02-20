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

            int[] platesInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int counter = 0;

            Stack<int> plates = new Stack<int>();
            Stack<int> orcs = new Stack<int>();

            int curentOrc = 0;
            int curentPlate = 0;

            for (int i = 0; i < platesInput.Length; i++)
            {
                plates.Push(platesInput[i]);
            }

            for (int i = 0; i < n; i++)
            {
                int[] orcsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
                counter++;

                if (counter % 3 == 0)
                {
                    int reinforcements = int.Parse(Console.ReadLine());
                    plates.Reverse();
                    plates.Push(reinforcements);
                    plates.Reverse();
                }

                if (plates.Count == 0)
                {
                    break;
                }

                for (int j = 0; j < orcsInput.Length; j++)
                {
                    orcs.Push(orcsInput[j]);
                }


                while (orcs.Count > 0 && plates.Count > 0)
                {
                    curentPlate = plates.Pop();
                    
                    while (curentPlate > 0)
                    {

                        if (orcs.Count == 0)
                        {
                            plates.Push(curentPlate);
                            break;
                        }
                        curentOrc = orcs.Pop();

                        if (curentOrc <= curentPlate)
                        {
                            curentPlate -= curentOrc;
                        }
                        else
                        {
                            curentOrc -= curentPlate;
                            curentPlate = 0;
                            orcs.Push(curentOrc);                         
                        }

                    }
                }
            }

            if (plates.Count > 0)
            {
                plates.Reverse();
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

using System;
using System.Collections.Generic;
using System.Linq;

namespace _005._Drum_Set
{
    class Program
    {
        static void Main(string[] args)
        {
            double savings = double.Parse(Console.ReadLine());
            List<int> drumSet = Console.ReadLine().Split().Select(int.Parse).ToList();
            string end = Console.ReadLine();
            List<int> replacement = new List<int>();
            

            for (int i = 0; i < drumSet.Count; i++)
            {
                replacement.Add(drumSet[i]);
            }

            while (end != "Hit it again, Gabsy!")
            {
                int hitPower = int.Parse(end);
               

                for (int i = 0; i < replacement.Count; i++)
                {
                    replacement[i] -= hitPower;

                    if (replacement[i] <= 0)
                    {
                        if ((savings - drumSet[i] * 3) < 0)
                        {
                            replacement.RemoveAt(i);
                            drumSet.RemoveAt(i);
                            i -= 1;
                        }
                        else
                        {
                            
                            replacement[i] = drumSet[i];
                            savings -= drumSet[i] * 3;

                        }
                    }
                }

                end = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", replacement));
            Console.WriteLine($"Gabsy has {savings:f2}lv.");
        }
    }
}

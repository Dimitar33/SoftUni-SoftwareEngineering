using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Pokemon_Don_t_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> pokemons = Console.ReadLine().Split().Select(int.Parse).ToList();

           
            int sum = 0;

            while (pokemons.Count > 0)
            {
                int cmd = int.Parse(Console.ReadLine());
                int removed = 0;

                
                if (cmd < 0)
                {
                    removed = pokemons[0];
                    sum += pokemons[0];
                    pokemons.Insert(0 , pokemons[pokemons.Count - 1]);
                    pokemons.Remove(pokemons[1]);
                }
                else if (cmd >= pokemons.Count)
                {
                    removed = pokemons[pokemons.Count - 1];
                    sum += pokemons[pokemons.Count - 1];
                    pokemons.Add(pokemons[0]);
                    pokemons.RemoveAt(pokemons.Count -2);
                }
                else
                {
                    removed = pokemons[cmd];
                    sum += pokemons[cmd];
                    pokemons.RemoveAt(cmd);
                }
                for (int i = 0; i < pokemons.Count; i++)
                {
                    if (pokemons[i] <= removed)
                    {
                        pokemons[i] += removed;

                    }
                    else
                    {
                        pokemons[i] -= removed;
                    }
                }
            }
            Console.WriteLine(sum);
        }
    }
}

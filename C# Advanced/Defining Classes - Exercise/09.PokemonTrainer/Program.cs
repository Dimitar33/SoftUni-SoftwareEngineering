using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonTrainer
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            List<Trainer> trainers = new List<Trainer>();
            List<Pokemon> pokemons = new List<Pokemon>();

            while (input[0] != "Tournament")
            {
                string trainerName = input[0];
                string pokemonName = input[1];
                string element = input[2];
                int pokemonHP = int.Parse(input[3]);

                Pokemon pokemon = new Pokemon(pokemonName, element, pokemonHP);

                if (!trainers.Any(c => c.Name == trainerName))
                {
                    Trainer trainer = new Trainer(trainerName, 0, new List<Pokemon>());

                    trainers.Add(trainer);
                }

                var index = trainers.FindIndex(c => c.Name == trainerName);

                trainers[index].Collection.Add(pokemon);


                input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            string cmd = Console.ReadLine();

            while (cmd != "End")
            {

                for (int i = 0; i < trainers.Count; i++)
                {
                    if (trainers[i].Collection.Any(c => c.Element == cmd))
                    {
                        trainers[i].Badges += 1;
                    }
                    else
                    {
                        trainers[i].Collection.Select(c => c.HP -= 10).ToList();

                        trainers[i].Collection =
                        trainers[i].Collection.Where(c => c.HP > 0).ToList();
                    }
                }
                cmd = Console.ReadLine();
            }

            foreach (var item in trainers.OrderByDescending(c => c.Badges))
            {
                Console.WriteLine($"{item.Name} {item.Badges} {item.Collection.Count}");
            }
        }
    }
}
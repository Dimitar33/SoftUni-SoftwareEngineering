using System;
using System.Collections.Generic;
using System.Text;

namespace _09.PokemonTrainer
{
    class Trainer
    {
        public string Name { get; set; }
        public int Badges { get; set; }
        public List<Pokemon> Collection { get; set; }

        public Trainer(string name, int badges, List<Pokemon> collection)
        {
            Name = name;
            Badges = badges;
            Collection = collection;
        }
    }
}

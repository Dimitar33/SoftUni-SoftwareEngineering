using System;
using System.Collections.Generic;
using System.Text;

namespace _09.PokemonTrainer
{
    class Pokemon
    {
        public string Name { get; set; }
        public string Element { get; set; }
        public int HP { get; set; }

        public Pokemon(string name, string element, int hp)
        {
            Name = name;
            Element = element;
            HP = hp;
        }
    }
}

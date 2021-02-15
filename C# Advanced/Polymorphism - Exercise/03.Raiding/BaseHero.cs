using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public abstract class BaseHero
    {
        public BaseHero(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public int Power { get; set; }
        public virtual string CastAbility()
        {
            return $"{GetType().Name} - {Name} ";
        }
    }
}

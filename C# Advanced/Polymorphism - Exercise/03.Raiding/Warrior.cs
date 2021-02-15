using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public class Warrior : BaseHero
    {
        public Warrior(string name) : base(name)
        {
        }

        public int Power { get => 100; }

        public override string CastAbility()
        {
            return base.CastAbility() + $"hit for {Power} damage";
        }
    }
}

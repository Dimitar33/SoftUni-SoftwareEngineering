using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public class Rogue : BaseHero
    {
        public Rogue(string name) : base(name)
        {
        }

        public int Power { get => 80;}

        public override string CastAbility()
        {
            return base.CastAbility() + $"hit for {Power} damage";
        }
    }
}

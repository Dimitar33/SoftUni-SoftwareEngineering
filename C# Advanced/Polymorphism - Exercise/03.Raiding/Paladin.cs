using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public class Paladin : BaseHero
    {
        public Paladin(string name) : base(name)
        {
        }

        public int Power { get => 100;}

        public override string CastAbility()
        {
            return base.CastAbility() + $"healed for {Power}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public class Druid : BaseHero
    {
        public Druid(string name) : base(name)
        {
        }

        public int Power { get => 80; }

        public override string CastAbility()
        {
            return base.CastAbility() + $"healed for {Power}";
        }
    }
}

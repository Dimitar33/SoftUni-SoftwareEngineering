using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters
{
    public class Warrior : Character, IAttacker
    {
        public Warrior(string name) : base(name)
        {
        }

        public override double MaxLife { get => 100; }
        public override double maxArmor { get => 50; }
        public void Attack(Character character)
        {
            throw new NotImplementedException();
        }
    }
}

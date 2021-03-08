using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters
{
    public class Priest : Character, IHealer
    {
        public Priest(string name) : base(name)
        {
        }

        public override double MaxLife { get => 50; }
        public override double maxArmor { get => 25; }
        public void Heal(Character character)
        {
            if (!this.IsAlive || !character.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }

            if (character.Health + this.AbilitytPoints > character.MaxLife)
            {
                character.Health = character.MaxLife;
            }
            else
            {
                character.Health += this.AbilitytPoints;
            }
        }
    }
}

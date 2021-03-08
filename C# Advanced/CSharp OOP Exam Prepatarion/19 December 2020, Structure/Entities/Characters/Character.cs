using System;

using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
          
        

        public Character(string name )
        {
            Name = name;
           
        }

        public virtual double maxArmor { get; }
        public virtual double MaxLife { get;}
        public Bag Bag { get; set; }
        public double AbilitytPoints { get => 40; }
        public double Armor { get => maxArmor; set => Armor = value; }
        public double Health { get => MaxLife; set => Health = value; }
        public bool IsAlive { get; set; } = true;
        public string Name 
		{
			get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
					throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }
				name = value;
            }
		}
        public void TakeDamage(double hitPoints)
        {
            EnsureAlive();
            if (Armor > hitPoints)
            {
                Armor -= hitPoints;
            }
            else if (hitPoints > Armor)
            {
                hitPoints -= Armor;
                Armor = 0;
            }
            if (Health > hitPoints)
            {
                Health -= hitPoints;
            }
            else
            {
                IsAlive = false;
            }
        }

        public void UseItem(Item item)
        {
            EnsureAlive();
        }

        protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}
	}
}
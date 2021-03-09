using System;
using System.Collections.Generic;
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
        public string Status { get => IsAlive ? "Alive" : "Dead"; }                        
        public double AbilitytPoints { get => 40; }
        public double Armor { get; set; }
        public double Health { get ; set ; }
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
                hitPoints = 0;
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
                Health = 0;
                IsAlive = false;

                Console.WriteLine("is dead");
            }
        }

        public void UseItem(Item item)
        {
            EnsureAlive();
            item.AffectCharacter(this);
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
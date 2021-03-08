﻿using System;

using WarCroft.Entities.Characters.Contracts;
using WarCroft.Constants;

namespace WarCroft.Entities.Items
{
	// Christmas came early this year - this class is already implemented for you!
	public abstract class Item
	{
        public Item()
        {

        }
		protected Item(int weight) : base()
		{
			this.Weight = weight;
		}

		public virtual int Weight { get; }

		public virtual void AffectCharacter(Character character)
		{
			if (!character.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}
	}
}

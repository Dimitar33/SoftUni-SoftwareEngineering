using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
        public List<Character> Party { get; set; }
        public Stack<Item> ItemPool { get; set; }
        public WarController()
		{
			Party = new List<Character>();
			ItemPool = new Stack<Item>();
		}

		public string JoinParty(string[] args)
		{
            if (args[0] != "Warrior" && args[0] != "Priest")
            {
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, args[0]));
            }
			Character character;

            if (args[0] == "Warrior")
            {
				character = new Warrior(args[1]);
            }
            else
            {
				character = new Priest(args[1]);
            }
			Party.Add(character);

            return string.Format(SuccessMessages.JoinParty, args[1]);
		}

		public string AddItemToPool(string[] args)
		{
			if (args[0] != "HealthPotion" && args[0] != "FirePotion")
			{
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, args[0]));
			}
			Item item;

			if (args[0] == "FirePotion")
			{
				item = new FirePotion();
			}
			else
			{
				item = new HealthPotion();
			}
			ItemPool.Push(item);

			return string.Format(SuccessMessages.AddItemToPool, args[0]);
		}

		public string PickUpItem(string[] args)
		{
			var currChar = Party.FirstOrDefault(x => x.Name == args[0]);
			if (currChar == null)
            {
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, args[0]));
            }
            if (ItemPool.Count == 0)
            {
				throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }
			
            if (currChar.Bag.Load + ItemPool.Peek().Weight > currChar.Bag.Capacity)
            {
				throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }
			string item = ItemPool.Peek().GetType().Name.ToString();			
			currChar.Bag.AddItem(ItemPool.Pop());

			return string.Format(SuccessMessages.PickUpItem, args[0], item);
		}

		public string UseItem(string[] args)
		{
			var currChar = Party.FirstOrDefault(x => x.Name == args[0]);
			if (currChar == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, args[0]));
			}
		 	var currItem = currChar.Bag.GetItem(args[1]);
			currItem.AffectCharacter(currChar);

			return string.Format(SuccessMessages.UsedItem, args[0], args[1]);
		}

		public string GetStats()
		{
			

			StringBuilder sb = new StringBuilder();

            foreach (var item in Party.OrderByDescending(x => x.Health))
            {
				sb.AppendLine($"{item.Name} - HP: {item.Health}/{item.MaxLife}, AP: {item.Armor}/{item.maxArmor}, Status: {item.Status}");
            }
			return sb.ToString().Trim();
		}

		public string Attack(string[] args)
		{
			var attacker = Party.FirstOrDefault(x => x.Name == args[0]);
			var receiver = Party.FirstOrDefault(x => x.Name == args[1]);

			if (attacker == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, args[0]));
			}
			if (receiver == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, args[1]));
			}
			if (!(attacker is Warrior))
			{
				throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, args[0]));
			}
			((Warrior)attacker).Attack(receiver);

			StringBuilder sb = new StringBuilder();

			sb.AppendLine( string.Format(SuccessMessages.AttackCharacter, 
				args[0], args[1], attacker.AbilitytPoints, args[1],
				receiver.Health, receiver.MaxLife, 
				receiver.Armor, receiver.maxArmor));

            if (receiver.Health == 0)
            {
				sb.AppendLine(string.Format(SuccessMessages.AttackKillsCharacter, receiver.Name));
            }
			return sb.ToString().Trim(); ;
		}

		public string Heal(string[] args)
		{
			var healer = Party.FirstOrDefault(x => x.Name == args[0]);
			var receiver = Party.FirstOrDefault(x => x.Name == args[1]);

			if (healer == null)
            {
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, args[0]));
            }
            if (receiver == null)
            {
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, args[1]));
			}
            if (!(healer is Priest))
            {
				throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, args[0]));
            }

			((Priest)healer).Heal(receiver);

			return string.Format(SuccessMessages.HealCharacter, args[0], args[1], healer.AbilitytPoints, args[1], receiver.Health);
		}
	}
}

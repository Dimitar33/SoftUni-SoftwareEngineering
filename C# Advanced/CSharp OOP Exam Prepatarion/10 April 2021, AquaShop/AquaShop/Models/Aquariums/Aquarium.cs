using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public class Aquarium : IAquarium
    {
        private string name;
        private List<IDecoration> decorations;
        private List<IFish> fishes;

        public Aquarium(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            decorations = new List<IDecoration>();
            fishes = new List<IFish>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName); // unique names??
                }
                name = value;
            }
        }

        public int Capacity { get; private set; }

        public int Comfort => decorations.Sum(x => x.Comfort);

        public ICollection<IDecoration> Decorations => decorations;

        public ICollection<IFish> Fish => fishes;

        public void AddDecoration(IDecoration decoration)
        {
            decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (fishes.Count == Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
            fishes.Add(fish);
        }

        public void Feed()
        {
            foreach (var item in fishes)
            {
                item.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Name} ({GetType().Name}):");
            sb.Append("Fish: ");
            sb.AppendLine(fishes.Count > 0 ? 
                string.Join(", ", fishes.Select(x => x.Name)) : "none");
            sb.AppendLine($"Decorations: {decorations.Count}");
            sb.AppendLine($"Comfort: {Comfort}");

            return sb.ToString().Trim();
        }

        public bool RemoveFish(IFish fish)
        {
            if (fishes.Contains(fish))
            {
                fishes.Remove(fish);
                return true;
            }
            return false;
        }
    }
}

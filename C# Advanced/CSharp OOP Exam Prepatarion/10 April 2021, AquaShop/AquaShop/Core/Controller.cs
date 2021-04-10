using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private List<IAquarium> aquariums;

        DecorationRepository decorations = new DecorationRepository();

        public Controller()
        {
            aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            Aquarium aquarium = null;
            if (aquariumType == "SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else if (aquariumType == "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            aquariums.Add(aquarium);

            return string.Format(OutputMessages.SuccessfullyAdded, aquarium.GetType().Name);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration = null;

            if (decorationType == "Plant")
            {
                decoration = new Plant();
            }
            else if (decorationType == "Ornament")
            {
                decoration = new Ornament(); // wrong namespace ??
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            decorations.Add(decoration);

            return $"Successfully added {decorationType}.";
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            Fish fish = null;

            if (fishType == "FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType == "SaltwaterFish")
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            var aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);

            if (!fish.CanLeaveInAquarium(aquarium.GetType().Name))
            {
                return OutputMessages.UnsuitableWater;
            }

            aquarium.AddFish(fish);
            return $"Successfully added {fishType} to {aquariumName}.";
        }

        public string CalculateValue(string aquariumName)
        {
            var aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            decimal price = aquarium.Fish.Sum(x => x.Price) + aquarium.Decorations.Sum(x => x.Price);

            return $"The value of Aquarium {aquariumName} is {price:f2}.";
        }

        public string FeedFish(string aquariumName)
        {
            var aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            aquarium.Feed();

            return $"Fish fed: {aquarium.Fish.Count}";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            var decoration = decorations.FindByType(decorationType);
            if (decoration == null) 
                // moje bi proverka za nesashtestuvasht akvaarium
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            aquarium.AddDecoration(decoration);
            decorations.Remove(decoration);
            return $"Successfully added {decorationType} to {aquariumName}.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in aquariums)
            {
                sb.AppendLine(item.GetInfo());             
            }

            return sb.ToString().Trim();
        }
    }
}

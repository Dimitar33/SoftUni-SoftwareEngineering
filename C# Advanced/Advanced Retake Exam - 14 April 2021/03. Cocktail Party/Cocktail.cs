using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        private List<Ingredient> ingredients;

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
            ingredients = new List<Ingredient>();
        }

        public List<Ingredient> Ingredients => ingredients;
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }
        public int CurrentAlcoholLevel => ingredients.Sum(x => x.Alcohol);

        public void Add(Ingredient ingredient)
        {
            if (ingredients.Any(x => x.Name == ingredient.Name))
            {
                return;
            }
            if (CurrentAlcoholLevel + ingredient.Alcohol > MaxAlcoholLevel)
            {
                return;
            }
            if (ingredients.Count == Capacity)
            {
                return;
            }
            ingredients.Add(ingredient);
        }

        public bool Remove(string name)
        {
            var ingrid = ingredients.FirstOrDefault(x => x.Name == name);
            if (ingrid == null)
            {
                return false;
            }

            ingredients.Remove(ingrid);
            return true;
        }

        public Ingredient FindIngredient(string name)
        {
            return ingredients.FirstOrDefault(x => x.Name == name);
          
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            return ingredients.OrderByDescending(x => x.Alcohol).FirstOrDefault();
           
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");

            foreach (var item in ingredients)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}

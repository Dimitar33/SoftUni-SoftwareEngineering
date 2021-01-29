using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.PizzaCalories
{
    class Pizza
    {
        private string name;

        private Dough dough;

        private List<Topping> topping;

        public Pizza(string name, Dough dough)
        {
            Name = name;
            Dough = dough;
            Topping = new List<Topping>();
        }

        public string Name 
        { 
            get => name;
            set
            {
                if (value.Length < 1 || value.Length > 15)
                {
                    Console.WriteLine("Pizza name should be between 1 and 15 symbols.");
                    Environment.Exit(0);
                }
                name = value;
            }
        }
        public Dough Dough { get; set; }
        public List<Topping> Topping { get; set; }
       

        public void AddTopping(Topping toping)
        {
            Topping.Add(toping);

            if (Topping.Count > 10)
            {
                Console.WriteLine("Number of toppings should be in range [0..10].");
                Environment.Exit(0);
            }
        }

        public double Calories()
        {
            double totalTop = Topping.Sum(c => c.ToppingCalories());
            double totalDou = Dough.DoughCalories();
            return totalDou + totalTop;
        }
    }
}

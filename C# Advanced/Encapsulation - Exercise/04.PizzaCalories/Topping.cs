using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.PizzaCalories
{
    class Topping
    {
        private string toppingType;

        private int grams;

        internal Topping(string toppingType, int grams)
        {
            ToppingType = toppingType;
            Grams = grams;
           
        }

       

        public string ToppingType 
        { 
            get => toppingType;
            set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    Console.WriteLine($"Cannot place {value} on top of your pizza.");
                    Environment.Exit(0);
                }
                toppingType = value;
            }
        }
        private int Grams
        { 
            get => grams;
            set
            {
                if (value < 1 || value > 50)
                {
                    Console.WriteLine($"{toppingType} weight should be in the range[1..50].");
                    Environment.Exit(0);
                }
                grams = value;
            }
        }
       
        internal double ToppingCalories()
        {

            double calories = 0;

            if (toppingType.ToLower() == "meat")
            {
                calories = 1.2;
            }
            else if (toppingType.ToLower() == "veggies")
            {
                calories = 0.8;
            }
            else if (toppingType.ToLower() == "cheese")
            {
                calories = 1.1;
            }
            else if (toppingType.ToLower() == "sauce")
            {
                calories = 0.9;
            }

            return grams * 2 * calories;
        }
    }
}

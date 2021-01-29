using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    class Dough
    {
        private string flourType;

        private string bakingTechnique;

        private int grams;
        internal Dough(string flourType, string bakingTechnique, int grams)
        {
            FlourType = flourType;
            Grams = grams;
            BakingTechnique = bakingTechnique;
        }

        private string FlourType 
        { 
            get => flourType;
            set
            {
                if (value != "white" && value != "wholegrain")
                {
                    Console.WriteLine("Invalid type of dough.");
                    Environment.Exit(0);
                }

                flourType = value;
            }
        }       
        private string BakingTechnique 
        { 
            get => bakingTechnique;
            set
            {
                if (value != "crispy" && value != "chewy" && value != "homemade")
                {
                    Console.WriteLine("Invalid type of dough.");
                    Environment.Exit(0);
                }

                bakingTechnique = value;
            }
        }
        private int Grams 
        { 
            get => grams;
            set
            {
                if (value < 1 || value > 200)
                {
                    Console.WriteLine("Dough weight should be in the range [1..200].");
                    Environment.Exit(0);
                }

                grams = value;
            }
        }
        
        internal double DoughCalories()
        {
            double flourCalories = 0;

            if (flourType == "white")
            {
                flourCalories = 1.5;
            }
            else
            {
                flourCalories = 1;
            }

            double techniqueCalories = 0;

            if (BakingTechnique == "crispy")
            {
                techniqueCalories = 0.9;
            }
            else if (BakingTechnique == "chewy")
            {
                techniqueCalories = 1.1;
            }
            else
            {
                techniqueCalories = 1;
            }

            return grams * 2 * techniqueCalories * flourCalories;
        }
    }
}

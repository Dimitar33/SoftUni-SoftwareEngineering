using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] liquidsInput = Console.ReadLine().Split().
                Select(int.Parse).ToArray();
            int[] ingridientsInput = Console.ReadLine().
                Split().Select(int.Parse).ToArray();

            Queue<int> liquids = new Queue<int>();
            Stack<int> ingrids = new Stack<int>();

            int bread = 0;
            int cake = 0;
            int fruitPie = 0;
            int pastry = 0;

            for (int i = 0; i < liquidsInput.Length; i++)
            {
                liquids.Enqueue(liquidsInput[i]);
            }
            for (int i = 0; i < ingridientsInput.Length; i++)
            {
                ingrids.Push(ingridientsInput[i]);
            }

            while (liquids.Count > 0 && ingrids.Count > 0)
            {
                int liquid = liquids.Dequeue();
                int ingrid = ingrids.Pop();

                if (liquid + ingrid == 25)
                {
                    bread++;
                }
                else if (liquid + ingrid == 50)
                {
                    cake++;
                }
                else if (liquid + ingrid == 75)
                {
                    pastry++;
                }
                else if (liquid + ingrid == 100)
                {
                    fruitPie++;
                }
                else
                {
                    ingrids.Push(ingrid + 3);
                }
            }

            if (bread > 0 && cake > 0 && pastry > 0 && fruitPie > 0)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }
            if (liquids.Count == 0)
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            if (ingrids.Count == 0)
            {
                Console.WriteLine("Ingredients left: none");
            }
            else
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingrids)}");
            }
            Console.WriteLine($"Bread: {bread}");
            Console.WriteLine($"Cake: {cake}");
            Console.WriteLine($"Fruit Pie: {fruitPie}");
            Console.WriteLine($"Pastry: {pastry}");
        }
    }
}

using System;

namespace _04.PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] pizzaInput = Console.ReadLine().Split();
            string[] doughInput = Console.ReadLine().ToLower().Split();
            string[] toppinghInput = Console.ReadLine().Split();

            Dough dough = new Dough(doughInput[1], doughInput[2], int.Parse(doughInput[3]));
            Pizza pizza = new Pizza(pizzaInput[1], dough);

            while (toppinghInput[0] != "END")
            {

 
                Topping topping = new Topping(toppinghInput[1], int.Parse(toppinghInput[2]) );

                pizza.AddTopping(topping);

                toppinghInput = Console.ReadLine().Split();
            }



            Console.WriteLine($"{pizza.Name} - {pizza.Calories():F2} Calories.");
        }
    }
}

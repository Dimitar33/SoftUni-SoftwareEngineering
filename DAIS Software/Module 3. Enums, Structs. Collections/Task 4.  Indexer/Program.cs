using System.Collections;
using System.Collections.Specialized;

namespace Task_4.__Indexer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Drink drink = new Drink() { Ingridient = "cola", Name = "IceCola" };
            Menu menu = new Menu();
            menu.Drinks.Add(drink);

            string ingridient = menu[0]["cola"];

            Console.WriteLine(ingridient);
                
        }

        class Drink
        {
            public string Name { get; set; }

            public string Ingridient { get; set; }

            public string this[string name]
            {
                get => this.Ingridient;
                set => this[name] = value;
            }
        }
        class Menu
        {

            public int Id { get; set; }
            public List<Drink> Drinks { get; set; } = new List<Drink>();

            public Drink this[int idx]
            {
                get => Drinks[idx];
                set => Drinks[idx] = value;
            }
            
        }
    }
}
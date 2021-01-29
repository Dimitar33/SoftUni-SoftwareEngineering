using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] ppl = Console.ReadLine().
                Split(new string[] { ";", "=" }, StringSplitOptions.RemoveEmptyEntries);

            string[] items = Console.ReadLine().
                Split(new string[] { ";", "=" }, StringSplitOptions.RemoveEmptyEntries);

            List<Person> people = new List<Person>();

            List<Product> products = new List<Product>();

            for (int i = 0; i < ppl.Length; i += 2)
            {
                Person person = new Person(ppl[i], int.Parse(ppl[i + 1]));

                people.Add(person);
            }


            for (int i = 0; i < items.Length; i += 2)
            {
                Product product = new Product(items[i], int.Parse(items[i + 1]));

                products.Add(product);
            }

            string[] cmd = Console.ReadLine().Split();

            while (cmd[0] != "END")
            {
                Person personNeeded = people.First(c => c.Name == cmd[0]);
                Product prodNeeded = products.First(c => c.Name == cmd[1]);


                if (personNeeded.Money >= prodNeeded.Price)
                {
                    personNeeded.Money -= prodNeeded.Price;
                    personNeeded.Bag.Add(prodNeeded.Name);

                    Console.WriteLine($"{personNeeded.Name} bought {prodNeeded.Name}");
                }
                else
                {
                    Console.WriteLine($"{personNeeded.Name} can't afford {prodNeeded.Name}");
                }
                cmd = Console.ReadLine().Split();
            }

            foreach (var item in people)
            {
                if (item.Bag.Count == 0)
                {
                    Console.WriteLine($"{item.Name} - Nothing bought");
                }
                else
                {
                    Console.WriteLine($"{item.Name} - {string.Join(", ", item.Bag)}");
                }
            }
        }
    }
}

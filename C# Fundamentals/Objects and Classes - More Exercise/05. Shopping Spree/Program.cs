using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05._Shopping_Spree
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] ppl = Console.ReadLine().Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);
            string[] prod = Console.ReadLine().Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);

            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            for (int i = 0; i < ppl.Length; i += 2)
            {
                Person person = new Person();
                
                person.Name = ppl[i];             
                person.Money = int.Parse(ppl[i + 1]);             
                people.Add(person);
                


            }
            for (int i = 0; i < prod.Length; i+=2)
            {
                Product product = new Product();

                product.Name = prod[i];
                product.Prise = int.Parse(prod[i + 1]);
                products.Add(product);
            }
            string[] order = Console.ReadLine().Split();

            StringBuilder sb = new StringBuilder();
            while (order[0] != "END")
            {
                int prodPrice = 0;


                for (int i = 0; i < products.Count; i++)
                {
                    if (order[1] == products[i].Name)
                    {
                        prodPrice = products[i].Prise;


                    }
                }



                for (int i = 0; i < people.Count; i++)
                {
                    if (order[0] == people[i].Name)
                    {
                        if (people[i].Money >= prodPrice)
                        {
                            people[i].Money -= prodPrice;
                            Product product = new Product();
                            people[i].Products.Add(order[1]);

                            sb.AppendLine($"{people[i].Name} bought {order[1]}");
                        }
                        else
                        {
                            sb.AppendLine($"{people[i].Name} can't afford {order[1]}");
                        }
                        break;
                    }
                }
                order = Console.ReadLine().Split();
            }
            Console.WriteLine(sb.ToString().TrimEnd());
            foreach (Person item in people)
            {
                if (item.Products.Count == 0)
                {
                    Console.WriteLine($"{item.Name} - Nothing bought ");
                }
                else
                {

                    Console.WriteLine($"{item.Name} - {string.Join(", ", item.Products)}");
                }

            }
        }

        class Person
        {
            public Person()
            {
                Products = new List<string>();
            }
            public string Name { get; set; }
            public int Money { get; set; }
            public List<string> Products { get; set; }



        }
        class Product
        {
            public string Name { get; set; }
            public int Prise { get; set; }
        }
    }
}

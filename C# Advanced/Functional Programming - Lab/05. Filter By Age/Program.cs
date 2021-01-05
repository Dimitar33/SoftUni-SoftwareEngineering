using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Filter_By_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Person> ppl = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ");

                Person person = new Person();

                person.Name = input[0];
                person.Age = int.Parse(input[1]);

                ppl.Add(person);
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            if (condition == "younger")
            {
                ppl = ppl.Where(c => c.Age < age).ToList();
            }
            else 
            {
                ppl = ppl.Where(c => c.Age >= age).ToList();
            }

            foreach (var item in ppl)
            {
                if (format == "name")
                {
                    Console.WriteLine(item.Name);
                }
                else if (format == "age")
                {
                    Console.WriteLine(item.Age);
                }
                else
                {
                    Console.WriteLine($"{item.Name} - {item.Age}");
                }
            }
        }

        


        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}

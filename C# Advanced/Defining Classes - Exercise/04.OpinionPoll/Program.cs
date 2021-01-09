using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
           
            int n = int.Parse(Console.ReadLine());

            List<Person> family = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] pplData = Console.ReadLine().Split();

                string name = pplData[0];
                int age = int.Parse(pplData[1]);

                Person person = new Person();

                person.Name = name;
                person.Age = age;

                family.Add(person);
            }

            family = family.Where(c => c.Age > 30).OrderBy(c => c.Name).ToList();

            foreach (var item in family)
            {
                Console.WriteLine($"{item.Name} - {item.Age}");
            }
           

        }
                   
        
    }
}

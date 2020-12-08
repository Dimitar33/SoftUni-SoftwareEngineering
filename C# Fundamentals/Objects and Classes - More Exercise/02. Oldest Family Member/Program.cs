using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace _02._Oldest_Family_Member
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Person> people = new List<Person>();



            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();

                Person person = new Person();
                person.Name = data[0];
                person.Age = int.Parse (data[1]);

                people.Add(person);
            }

            people = people.OrderByDescending(c => c.Age).ToList();

            Console.WriteLine(people[0].Name +" " + people[0].Age);
        }

        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }

        }
    }
}

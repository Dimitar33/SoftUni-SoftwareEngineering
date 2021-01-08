using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            AddPerson();

        }

        private static void AddPerson()
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
        }
    }
}

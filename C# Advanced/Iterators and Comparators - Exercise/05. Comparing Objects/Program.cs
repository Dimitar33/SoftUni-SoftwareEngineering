using System;
using System.Collections.Generic;

namespace _05._Comparing_Objects
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] pplInfo = Console.ReadLine().Split();

            List<Person> people = new List<Person>();

            while (pplInfo[0] != "END")
            {
                string name = pplInfo[0];
                int age = int.Parse(pplInfo[1]);
                string town = pplInfo[2];

                Person person = new Person(name, age, town);

                people.Add(person);

                pplInfo = Console.ReadLine().Split();
            }

            int n = int.Parse(Console.ReadLine());

            int match = 0;

            Person etalon = people[n - 1];

            foreach (var item in people)
            {
                if (item.CompareTo(etalon) == 0)
                {
                    match++;
                }
            }

            if (match == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{match} {people.Count - match} {people.Count}");
            }
        }
    }
}

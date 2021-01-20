using System;
using System.Collections.Generic;

namespace _06.EqualityLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<Person> hashsetPeople = new HashSet<Person>();
            SortedSet<Person> sortedPeople = new SortedSet<Person>();
                  

            for (int i = 0; i < n; i++)
            {
                string[] personInfo = Console.ReadLine().Split();

                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                Person person = new Person(name, age);

                hashsetPeople.Add(person);
                sortedPeople.Add(person);
            }

            Console.WriteLine(hashsetPeople.Count);
            Console.WriteLine(sortedPeople.Count);
        }
    }
}

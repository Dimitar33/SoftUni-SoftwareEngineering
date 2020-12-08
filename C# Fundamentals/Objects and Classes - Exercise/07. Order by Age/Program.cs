using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07._Order_by_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] data = Console.ReadLine().Split();

            List<Person> ppl = new List<Person>();

            while (data[0] != "End")
            {
                Person person = new Person();
                person.Name = data[0];
                person.ID = data[1];
                person.Age =int.Parse( data[2]);

                ppl.Add(person);

                data = Console.ReadLine().Split();
            }
            ppl = ppl.OrderBy(c => c.Age).ToList();


            foreach (Person item in ppl)
            {
                Console.WriteLine($"{item.Name} with ID: {item.ID} is {item.Age} years old.");
            }

        }
        class Person
        {
            public string Name { get; set; }
            public string ID { get; set; }
            public int Age { get; set; }

           
        }
    }
}

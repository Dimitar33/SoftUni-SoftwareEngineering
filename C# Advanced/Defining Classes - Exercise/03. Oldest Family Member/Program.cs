﻿using System;
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
            
            Console.WriteLine($"{Oldest(family).Name} {Oldest(family).Age}");
           

        }
                   
        static Person Oldest(List<Person> ppl)
        {
            var oldest = ppl.OrderByDescending(c => c.Age).First();

            return oldest;
        }
    }
}

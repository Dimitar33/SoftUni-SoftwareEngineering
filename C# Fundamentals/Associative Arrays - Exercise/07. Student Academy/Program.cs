using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var notebook = new Dictionary<string, double>();

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (notebook.ContainsKey(name))
                {
                    notebook[name] = (notebook[name] + grade) / 2;
                }
                else
                {
                    notebook.Add(name, grade);
                }

            }

            notebook = notebook.Where(c => c.Value >= 4.5).OrderByDescending(c => c.Value).ToDictionary(c => c.Key, c => c.Value);

            foreach (var item in notebook)
            {
                Console.WriteLine($"{item.Key} -> {item.Value:f2}");
            }
        }
    }
}

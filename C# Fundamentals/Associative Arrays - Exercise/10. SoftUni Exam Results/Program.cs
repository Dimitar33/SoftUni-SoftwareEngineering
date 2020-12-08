using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace _10._SoftUni_Exam_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] data = Console.ReadLine().Split("-");

            var people = new Dictionary<string, int>();
            var submissions = new Dictionary<string, int>();

            while (data[0] != "exam finished")
            {
                if (data[1] == "banned")
                {
                    people.Remove(data[0]);
                    data = Console.ReadLine().Split("-");
                    continue;
                }
                int points = int.Parse(data[2]);

                if (!submissions.ContainsKey(data[1]))
                {
                    submissions.Add(data[1], 1);
                }
                else
                {
                    submissions[data[1]]++;
                }
                if (!people.ContainsKey(data[0]))
                {
                    people.Add(data[0], points);
                }
                else if (people[data[0]] < points)
                {
                    people[data[0]] = points;
                }


                data = Console.ReadLine().Split("-");
            }

            Console.WriteLine("Results:");
            foreach (var item in people.OrderByDescending(c => c.Value).ThenBy(c => c.Key))
            {
                Console.WriteLine($"{item.Key} | {item.Value}");
            }
            Console.WriteLine("Submissions:");
            foreach (var item in submissions.OrderByDescending(c => c.Value).ThenBy(c => c.Key))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }

        }
    }
}

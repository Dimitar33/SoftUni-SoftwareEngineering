using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02._Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] student = Console.ReadLine().Split();
                decimal score = decimal.Parse(student[1]);

                if (students.ContainsKey(student[0]))
                {
                    students[student[0]].Add(score);
                }
                else
                {
                    students.Add(student[0], new List<decimal>());
                    students[student[0]].Add(score); 
                }
            }
            
            foreach (var item in students)
            {
                Console.WriteLine($"{item.Key} -> {string.Join(" ", item.Value.Select(c => $"{c:f2}"))} (avg: {item.Value.Average():f2})");
            }
        }
    }
}

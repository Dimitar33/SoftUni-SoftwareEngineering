using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Student> students = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();
                Student student = new Student(data[0], data[1], double.Parse(data[2]));

                students.Add(student);

            }

            students = students.OrderBy(c => c.Grade).ToList();
            students.Reverse();

            foreach (Student item in students)
            {

                Console.WriteLine(item.ToString());

            }
        }
        class Student
        {
            public Student(string firstName, string lastName, double grade)
            {

                FirstsName = firstName;
                LastName = lastName;
                Grade = grade;

            }
            public string FirstsName { get; set; }
            public string LastName { get; set; }
            public double Grade { get; set; }

            public override string ToString()
            {
                return $"{FirstsName} {LastName}: {Grade:f2}";
            }
        }
    }
}

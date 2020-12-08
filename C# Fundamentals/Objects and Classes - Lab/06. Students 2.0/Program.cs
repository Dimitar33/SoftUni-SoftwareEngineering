using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Students
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> info = Console.ReadLine().Split().ToList();

            List<Student> studentList = new List<Student>();
            Student stud = new Student();

            while (info[0] != "end")
            {
                 stud = studentList.FirstOrDefault(c => c.firstName == info[0] &&
                                                         c.lastName == info[1]);

                if (stud == null)
                {
                    stud = new Student();

                    stud.firstName = info[0];
                    stud.lastName = info[1];
                    stud.age = int.Parse(info[2]);
                    stud.city = info[3];

                    studentList.Add(stud);
                }
                else
                {
                    stud.firstName = info[0];
                    stud.lastName = info[1];
                    stud.age = int.Parse(info[2]);
                    stud.city = info[3];
                }
                info = Console.ReadLine().Split().ToList();

            }
            string town = Console.ReadLine();

            List<Student> filter = studentList.Where(c => c.city == town).ToList();


            foreach (Student i in filter)
            {

                Console.WriteLine($"{i.firstName} {i.lastName} is {i.age} years old.");
            }

        }

        class Student
        {
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string city { get; set; }
            public int age { get; set; }
        }
    }
}

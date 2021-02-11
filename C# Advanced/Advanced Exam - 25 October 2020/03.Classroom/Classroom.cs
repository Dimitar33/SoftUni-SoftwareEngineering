using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        public Classroom(int capacity)
        {
            Capacity = capacity;
            Students = new List<Student>();
        }

        public int Capacity { get; }
        public int Count { get => Students.Count; }
        public List<Student> Students { get;  }

        public string RegisterStudent(Student student)
        {
            if (Count < Capacity)
            {
                Students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }

            return "No seats in the classroom";

        }

        public string DismissStudent(string firstName, string lastName)
        {
            Student student = Students.FirstOrDefault(c => c.FirstName == firstName && c.LastName == lastName);

            if (student == null)
            {
                return "Student not found";
            }

            return $"Dismissed student {student.FirstName} {student.LastName}";

        }

        public string GetSubjectInfo(string subject)
        {
            List<Student> needed = Students.Where(c => c.Subject == subject).ToList();

            if (needed.Count == 0)
            {
                return "No students enrolled for the subject";
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Subject: {subject}");
            sb.AppendLine("Students:");

            foreach (var item in needed)
            {
                sb.AppendLine($"{item.FirstName} {item.LastName}");
            }

            return sb.ToString().TrimEnd();
        }

        public Student GetStudent(string firstName, string lastName)
        {
            return Students.FirstOrDefault(c => c.FirstName == firstName && c.LastName == lastName);
        }

        public int GetStudentsCount() => Students.Count;
    }
}

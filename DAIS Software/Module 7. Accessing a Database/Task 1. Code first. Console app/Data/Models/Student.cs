using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1._Code_first._Console_app.Data.Models
{
    internal class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public double Grade { get; set; }
        public bool IsInClass { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();

    }
}

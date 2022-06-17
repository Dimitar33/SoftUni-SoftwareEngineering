using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1._Code_first._Console_app.Data.Models
{
    internal class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Column(TypeName = "decimal(15,2)")]
        public decimal Salary { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();

    }
}

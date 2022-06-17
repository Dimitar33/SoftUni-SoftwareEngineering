using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1._Code_first._Console_app.Data.Models
{
    internal class Course
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
    }
}

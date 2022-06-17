using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1._Code_first._Console_app.Data.Models
{
    internal class CourseStudent
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}

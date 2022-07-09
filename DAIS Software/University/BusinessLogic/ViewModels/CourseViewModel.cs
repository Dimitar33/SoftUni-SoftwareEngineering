using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ViewModels
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Descriotion { get; set; }
        public int? TeacherId { get; set; }
        public string TeacherName { get; set; }

        public int Likes { get; set; }
        public int Dificulty { get; set; }
        public int StudentsCount { get; set; }
        public string CourseModules { get; set; }

    }
}

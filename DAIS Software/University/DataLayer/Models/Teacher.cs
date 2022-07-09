using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            Courses = new HashSet<Course>();
        }

        public int UserId { get; set; }
        public decimal? Sallary { get; set; }
        public int? ExperienceYears { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<Course> Courses { get; set; }
    }
}

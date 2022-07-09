using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    public partial class Course
    {
        public Course()
        {
            CourseMaterials = new HashSet<CourseMaterial>();
            CourseModules = new HashSet<CourseModule>();
            CourseVotes = new HashSet<CourseVote>();
            Scores = new HashSet<Score>();
            Tests = new HashSet<Test>();
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Descriotion { get; set; }
        public int? TeacherId { get; set; }
        public int Dificulty { get; set; }
        public int Likes { get; set; }
        public int StudentsCount { get; set; }

        public virtual Teacher? Teacher { get; set; }
        public virtual ICollection<CourseMaterial> CourseMaterials { get; set; }
        public virtual ICollection<CourseModule> CourseModules { get; set; }
        public virtual ICollection<CourseVote> CourseVotes { get; set; }
        public virtual ICollection<Score> Scores { get; set; }
        public virtual ICollection<Test> Tests { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    public partial class Student
    {
        public Student()
        {
            CourseVotes = new HashSet<CourseVote>();
            Scores = new HashSet<Score>();
            Courses = new HashSet<Course>();
        }

        public int UserId { get; set; }
        public int? VoteId { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<CourseVote> CourseVotes { get; set; }
        public virtual ICollection<Score> Scores { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}

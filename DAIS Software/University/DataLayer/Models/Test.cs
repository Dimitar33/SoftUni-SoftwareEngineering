using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    public partial class Test
    {
        public Test()
        {
            Questions = new HashSet<Question>();
            TestResults = new HashSet<TestResult>();
        }

        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? CourseId { get; set; }
        public int Duration { get; set; }

        public virtual Course? Course { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<TestResult> TestResults { get; set; }
    }
}

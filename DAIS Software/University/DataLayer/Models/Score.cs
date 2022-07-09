using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    public partial class Score
    {
        public int Score1 { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }

        public virtual Course Course { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    public partial class CourseVote
    {
        public bool Disliked { get; set; }
        public bool Liked { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }

        public virtual Course Course { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    public partial class TestResult
    {
        public int Id { get; set; }
        public string CourseName { get; set; } = null!;
        public string StudentNames { get; set; } = null!;
        public string Result { get; set; } = null!;
        public int UserId { get; set; }
        public int? TestId { get; set; }

        public virtual Test? Test { get; set; }
        public virtual User User { get; set; } = null!;
    }
}

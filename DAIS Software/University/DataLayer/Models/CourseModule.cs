using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    public partial class CourseModule
    {
        public int Id { get; set; }
        public int? CourseId { get; set; }
        public string Description { get; set; } = null!;
        public string Name { get; set; } = null!;

        public virtual Course? Course { get; set; }
    }
}

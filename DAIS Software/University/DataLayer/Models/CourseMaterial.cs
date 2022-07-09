using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    public partial class CourseMaterial
    {
        public int Id { get; set; }
        public int? CourseId { get; set; }
        public string Type { get; set; } = null!;
        public string Url { get; set; } = null!;

        public virtual Course? Course { get; set; }
    }
}

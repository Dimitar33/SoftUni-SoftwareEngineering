using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    public partial class User
    {
        public User()
        {
            TestResults = new HashSet<TestResult>();
            Roles = new HashSet<Role>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public string UserType { get; set; } = null!;
        public int Age { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        public virtual Student Student { get; set; } = null!;
        public virtual Teacher Teacher { get; set; } = null!;
        public virtual ICollection<TestResult> TestResults { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}

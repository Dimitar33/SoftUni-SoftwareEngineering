using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string FirstName { get; set; } = null!;

        [StringLength(20, MinimumLength = 3)]
        public string? LastName { get; set; }

        [Required]
        [Range(14, 100)]
        public int Age { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [MaxLength(15)]
        public string? Phone { get; set; }

        public List<CourseViewModel> Courses { get; set; } = new List<CourseViewModel>();
        public string? Role { get; set; }
    }
}

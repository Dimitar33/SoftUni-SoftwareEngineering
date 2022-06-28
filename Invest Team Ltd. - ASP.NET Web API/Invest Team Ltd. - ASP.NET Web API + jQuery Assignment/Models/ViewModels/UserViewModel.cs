using Invest_Team_Ltd.___ASP.NET_Web_API___jQuery_Assignment.Models.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Invest_Team_Ltd.___ASP.NET_Web_API___jQuery_Assignment.Models.ViewModels
{
    public class UserViewModel
    {
        [Required]
        [StringLength(20,
            MinimumLength = 2,
            ErrorMessage = "First name must be between {2} and {1} simbols")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20,
            MinimumLength = 2,
            ErrorMessage = "Last name must be between {2} and {1} simbols")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public Role Role { get; set; }
    }
}

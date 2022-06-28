using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Invest_Team_Ltd.___ASP.NET_Web_API___jQuery_Assignment.Models.ViewModels
{
    public class CarViewModel
    {

        [Required]
        [StringLength(30, 
            MinimumLength = 2, 
            ErrorMessage = "Make must be between {2} and {1} simbols")]
        public string Make { get; set; }

        [Required]
        [StringLength(20,
            MinimumLength = 3,
            ErrorMessage = "Color must be between {2} and {1} simbols")]
        public string Color { get; set; }

        public string Registration { get; set; }
    }
}

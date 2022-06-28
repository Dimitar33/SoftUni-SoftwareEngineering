using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Invest_Team_Ltd.___ASP.NET_Web_API___jQuery_Assignment.Models
{
    public class Problem
    {
        public int Id { get; init; }
        public DateTime Date { get; set; }

        [Required]
        [StringLength(300, MinimumLength = 5)]
        public string Description { get; set; }

        [Required]
        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}

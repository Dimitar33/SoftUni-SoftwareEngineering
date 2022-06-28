using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Invest_Team_Ltd.___ASP.NET_Web_API___jQuery_Assignment.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Color { get; set; }

        public string Registration { get; set; }

        [ForeignKey("Problem")]
        public int ProblemId { get; set; }
        public Problem Problem { get; set; }

    }
}

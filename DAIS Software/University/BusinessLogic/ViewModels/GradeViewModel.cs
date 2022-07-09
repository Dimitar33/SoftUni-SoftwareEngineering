using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ViewModels
{
    public class GradeViewModel
    {
        public int CoureseId { get; set; }
        public int SudentId { get; set; }

        [Required]
        [Range(2, 6, ErrorMessage ="Grade must be between 2 and 6")]
        public int Score { get; set; }
        public string? StudentsNames { get; set; }

        public string? Course { get; set; }
    }
}

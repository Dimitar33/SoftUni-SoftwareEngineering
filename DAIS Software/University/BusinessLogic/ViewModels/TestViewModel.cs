using BusinessLogic.ViewModels.ModelValidators;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ViewModels
{
    public class TestViewModel 
    {
        public int Id { get; set; }

        [Required]
        [DateValidation(ErrorMessage ="Invalid date")]
        public DateTime StartDate { get; set; }

        [Required]
        [DateLessThanAttribute(
            "StartDate",
            ErrorMessage ="End date must be greater than start date!")]
        public DateTime EndDate { get; set; }
        public int? CourseId { get; set; }

        [Required]
        [Range(15, 120,ErrorMessage ="Duration must be between 15 and 120 mintes")]
        public int Duration { get; set; }

        public virtual ICollection<QuestionViewModel> Questions { get; set; } = new List<QuestionViewModel>();

       
    }
}

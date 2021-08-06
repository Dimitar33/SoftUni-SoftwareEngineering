using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static PetsDates.Data.DataConstants;
using System.Threading.Tasks;

namespace PetsDates.Models.Moderator
{
    public class ModFormModel
    {
        [Required]
        [StringLength(
            UserNameMaxLenght, 
            MinimumLength = UserNameMinLenght,
            ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
        public string UserName { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
    }
}

using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static PetsDates.Data.DataConstants;


namespace PetsDates.Data.Models
{
    public class User : IdentityUser
    {

        [Required]
        [MaxLength(UserNameMaxLenght)]
        public string FirtsName { get; set; }

        [Required]
        [MaxLength(UserNameMaxLenght)]
        public string LastName { get; set; }

        public IEnumerable<Pet> Pets { get; set; } = new List<Pet>();


    }
}

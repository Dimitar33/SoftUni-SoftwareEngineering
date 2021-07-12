using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static PetsDates.Data.DataConstants;


namespace PetsDates.Data.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(UserNameMaxLenght)]
        public string FirtsName { get; set; }

        [Required]
        [MaxLength(UserNameMaxLenght)]
        public string SecondName { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public ICollection<Pet> Pets { get; set; } = new List<Pet>();
    }
}

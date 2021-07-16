using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static PetsDates.Data.DataConstants;
namespace PetsDates.Models.Pets
{
    public class AddPetViewModel
    {
        [Required]
        [StringLength(
            PetNameMaxLenght,
            MinimumLength = PetNameMinLenght,
            ErrorMessage = "Name must be between {2} and {1} simbols")]
        public string Name { get; set; }

        [Required]
        [Range(PetMinAge, PetMaxAge,
            ErrorMessage = "Age must be between {1} and {2} years")]
        public double? Age { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [Url]
        public string PictureUrl { get; set; }

        public string Comment { get; set; }

        public int BreedId { get; set; }

        public IEnumerable<PetBreedViewModel> Breeds { get; set; }
            = new List<PetBreedViewModel>();
    }
}

using PetsDates.Data.Models;
using System.ComponentModel.DataAnnotations;
using static PetsDates.Data.DataConstants;

namespace PetsDates.Models.Cats
{
    public class AddCatViewModel
    {
        [Required]
        public CatBreed Breed { get; set; }

        [Required]
        [MaxLength(PetNameMaxLenght)]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [Url]
        public string PictureUrl { get; set; }

        public string Comment { get; set; }
    }
}

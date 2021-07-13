using PetsDates.Data.Models;
using System.ComponentModel.DataAnnotations;
using static PetsDates.Data.DataConstants;

namespace PetsDates.Models.Dogs
{
    public class AddDogViewModel
    {
        [Required]
        public DogBreed Breed { get; set; }

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

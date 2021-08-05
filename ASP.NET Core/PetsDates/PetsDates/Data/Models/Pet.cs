using System.ComponentModel.DataAnnotations;
using static PetsDates.Data.DataConstants;

namespace PetsDates.Data.Models
{
    public class Pet
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(PetNameMaxLenght)]
        public string Name { get; set; }

        [Required]
        public double? Age { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [Url]
        public string PictureUrl { get; set; }

        [Required]
        public Breed Breed { get; set; }

        [Required]
        public PetPurpose Purpose { get; set; }

        public double? Price { get; set; }

        public string Comment { get; set; }

        public string UserId { get; set; }
        public User Owner { get; set; }
    }
}

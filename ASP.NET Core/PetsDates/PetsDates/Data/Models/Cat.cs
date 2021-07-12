using System.ComponentModel.DataAnnotations;
using static PetsDates.Data.DataConstants;

namespace PetsDates.Data.Models
{
    public class Cat : Pet
    {
        public int CatBreedId { get; set; }
        public CatBreed Breed { get; set; }
    }
}

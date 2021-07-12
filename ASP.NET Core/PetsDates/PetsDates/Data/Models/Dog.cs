using System.ComponentModel.DataAnnotations;
using static PetsDates.Data.DataConstants;

namespace PetsDates.Data.Models
{
    public class Dog : Pet
    {
        public int DogBreedId { get; set; }
        public DogBreed Breed { get; set; }
    }
}



namespace PetsDates.Data.Models.Dogs
{
    public class Dog : Pet
    {
        public int DogBreedId { get; set; }
        public DogBreed Breed { get; set; }
    }
}

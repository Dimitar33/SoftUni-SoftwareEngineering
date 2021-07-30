
namespace PetsDates.Data.Models.Cats
{
    public class Cat : Pet
    {
        public int CatBreedId { get; set; }
        public CatBreed Breed { get; set; }
    }
}


namespace PetsDates.Data.Models
{
    public class Cat : Pet
    {
        public int CatBreedId { get; set; }
        public CatBreed Breed { get; set; }
    }
}

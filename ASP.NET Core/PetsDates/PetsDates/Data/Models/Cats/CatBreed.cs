using System.Collections.Generic;


namespace PetsDates.Data.Models.Cats
{
    public class CatBreed : Breed
    {
        public IEnumerable<Cat> Cats { get; set; } = new List<Cat>();
    }
}

using System.Collections.Generic;

namespace PetsDates.Data.Models.Dogs
{
    public class DogBreed : Breed
    {
        public IEnumerable<Dog> Dogs { get; set; } = new List<Dog>();
    }
}

using System.Collections.Generic;

namespace PetsDates.Data.Models
{
    public class DogBreed
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Dog> Cats { get; set; } = new List<Dog>();
    }
}

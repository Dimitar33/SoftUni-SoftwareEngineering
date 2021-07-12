using System.Collections.Generic;


namespace PetsDates.Data.Models
{
    public class CatBreed
    {
        public int Id { get; set; }
        public string Breed { get; set; }
        public IEnumerable<Cat> Cats { get; set; } = new List<Cat>();
    }
}

using System.Collections.Generic;

namespace PetsDates.Data.Models
{
    public class Breed
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Pet> Pets { get; set; } = new List<Pet>();
    }
}

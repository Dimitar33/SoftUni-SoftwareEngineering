using System.Collections.Generic;

namespace PetsDates.Services.Pets
{
    public class PetsQueryServiceModel
    {
        public int CurrentPage { get; set; }
        public int PetsPerPage { get; set; }
        public int TotalPets { get; set; }

        public IEnumerable<PetsListingServiceModel> Pets { get; set; }
    }
}

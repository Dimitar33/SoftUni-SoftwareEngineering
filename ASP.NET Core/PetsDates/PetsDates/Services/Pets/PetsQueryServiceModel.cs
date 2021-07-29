using PetsDates.Models.Pets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

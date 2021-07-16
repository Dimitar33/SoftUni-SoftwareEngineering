using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetsDates.Models.Pets
{
    public class AllPetsQueryModel
    {
        public IEnumerable<PetsListingViewModel> AllPets { get; set; } 
            = new List<PetsListingViewModel>();
    }
}

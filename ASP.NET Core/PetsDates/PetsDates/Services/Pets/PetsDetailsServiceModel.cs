using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetsDates.Services.Pets
{
    public class PetsDetailsServiceModel : PetsListingServiceModel
    {
        public int BreedId { get; set; }
        public string OwnerId { get; set; }
        public string  FirstName { get; set; }
        public string  LastName { get; set; }
        public string Comment { get; set; }
    }
}

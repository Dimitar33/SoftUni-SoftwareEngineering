using PetsDates.Services.Pets;
using System.Collections.Generic;

namespace PetsDates.Models.Home
{
    public class IndexViewModel
    {
        public List<PetsListingServiceModel> Pets { get; set; }
        = new List<PetsListingServiceModel>();
    }
}

using PetsDates.Models.Pets;
using System.Collections.Generic;

namespace PetsDates.Models.Home
{
    public class IndexViewModel
    {
        public List<PetsListingViewModel> Pets { get; set; }
        = new List<PetsListingViewModel>();
    }
}

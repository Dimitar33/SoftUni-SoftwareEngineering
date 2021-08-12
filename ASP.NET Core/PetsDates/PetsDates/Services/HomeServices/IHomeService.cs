using PetsDates.Services.Pets;
using System.Collections.Generic;

namespace PetsDates.Services.HomeServices
{
    public interface IHomeService
    {
        public IEnumerable<PetsListingServiceModel> CatsCarousel();
        public IEnumerable<PetsListingServiceModel> DogsCarousel();
    }
}

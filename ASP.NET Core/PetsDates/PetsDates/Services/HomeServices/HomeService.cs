using PetsDates.Data;
using PetsDates.Services.Pets;
using System.Collections.Generic;
using System.Linq;

namespace PetsDates.Services.HomeServices
{
    public class HomeService : IHomeService
    {
        private readonly PetsDatesDbContext data;

        public HomeService(PetsDatesDbContext data)
        {
            this.data = data;
        }

        public IEnumerable<PetsListingServiceModel> CatsCarousel()
        {
            var cats = data.Cats
                .OrderByDescending(x => x.Id)
                .Take(3)
                .Select(x => new PetsListingServiceModel
                {
                    Id = x.Id,
                    Breed = x.Breed.Name,
                    Age = x.Age,
                    Gender = x.Gender,
                    Name = x.Name,
                    PictureUrl = x.PictureUrl
                }).ToList();

            return cats;
        }
        public IEnumerable<PetsListingServiceModel> DogsCarousel()
        {
            var dogs = data.Dogs
                .OrderByDescending(x => x.Id)
                .Take(3)
                .Select(x => new PetsListingServiceModel
                {
                    Id = x.Id,
                    Breed = x.Breed.Name,
                    Age = x.Age,
                    Gender = x.Gender,
                    Name = x.Name,
                    PictureUrl = x.PictureUrl
                }).ToList();

            return dogs;
        }
    }
}

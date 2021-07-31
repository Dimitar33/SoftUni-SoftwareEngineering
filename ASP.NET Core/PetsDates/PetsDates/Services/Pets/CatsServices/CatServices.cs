using PetsDates.Data;
using PetsDates.Data.Models;
using PetsDates.Data.Models.Cats;
using PetsDates.Models.Pets;
using System.Collections.Generic;
using System.Linq;

namespace PetsDates.Services.Pets.CatsServices
{
    public class CatServices : ICatServices
    {
        private readonly PetsDatesDbContext data;

        public CatServices(PetsDatesDbContext data)
        {
            this.data = data;
        }

        public PetsQueryServiceModel AllCats(
            string breed,
            string gender,
            int purpose,
            string searchTerm,
            PetSorting sorting,
            int currentPage,
            int petsPerPage)
        {

            var catsQueary = data.Cats.AsQueryable();

            if (!string.IsNullOrWhiteSpace(breed))
            {
                catsQueary = catsQueary.Where(x =>
                     x.Breed.Breed == breed);
            }

            if (!string.IsNullOrWhiteSpace(gender))
            {
                catsQueary = catsQueary.Where(x => x.Gender == gender);
            }

            catsQueary = purpose switch
            {
                1 => catsQueary.Where(p => p.Purpose == (PetPurpose)1),
                2 => catsQueary.Where(p => p.Purpose == (PetPurpose)2),
                3 => catsQueary.Where(p => p.Purpose == (PetPurpose)3),
                _ => catsQueary
            };
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                catsQueary = catsQueary.Where(x =>
                (x.Breed.Breed + " " + x.Gender).ToLower().Contains(searchTerm.ToLower()) ||
                x.Comment.ToLower().Contains(searchTerm.ToLower()));
            }

            catsQueary = sorting switch
            {
                PetSorting.Age => catsQueary.OrderBy(x => x.Age),
                PetSorting.DateCreated => catsQueary.OrderByDescending(x => x.Id),
                PetSorting.Price => catsQueary.OrderBy(x => x.Price),
                _ => catsQueary
            };

            var catsCount = catsQueary.Count();

            var cats = catsQueary
                .Skip((currentPage - 1) * AllPetsQueryModel.PetsPerPage)
                .Take(AllPetsQueryModel.PetsPerPage)
                .Select(x => new PetsListingServiceModel
                {
                    Id = x.Id,
                    Breed = x.Breed.Breed,
                    Name = x.Name,
                    Purpose = x.Purpose,
                    Age = x.Age,
                    Gender = x.Gender,
                    Picture = x.PictureUrl
                }).ToList();

            return new PetsQueryServiceModel
            {
                CurrentPage = currentPage,
                PetsPerPage = petsPerPage,
                TotalPets = catsQueary.Count(),
                Pets = cats
            };
        }
        public int AddCat(
            int breedId,
            string gender,
            double? age,
            string name,
            int purpose,
            double? price,
            string pictureUrl,
            string comment,
            string userId)
        {
            var cat = new Cat
            {
                CatBreedId = breedId,
                Gender = gender,
                Age = age,
                Purpose = (PetPurpose)purpose,
                Price = price,
                PictureUrl = pictureUrl,
                Comment = comment,
                Name = name,
                UserId = userId
            };

            data.Cats.Add(cat);
            data.SaveChanges();

            return cat.Id;
        }

        public IEnumerable<PetsBreedServiceModel> GetCatBreeds()
        {
            return data.CatBreeds.Select(x => new PetsBreedServiceModel
            {
                Id = x.Id,
                Breed = x.Breed

            }).OrderBy(x => x.Breed).ToList();
        }
    }
}

using PetsDates.Data;
using PetsDates.Data.Models;
using PetsDates.Data.Models.Dogs;
using PetsDates.Models.Pets;
using System.Collections.Generic;
using System.Linq;

namespace PetsDates.Services.Pets.DogsServices
{
    public class DogServices : IDogServices
    {
        private readonly PetsDatesDbContext data;

        public DogServices(PetsDatesDbContext data)
        {
            this.data = data;
        }

        public PetsQueryServiceModel AllDogs(
           string breed,
           string gender,
           int purpose,
           string searchTerm,
           PetSorting sorting,
           int currentPage,
           int petsPerPage)
        {

            var dogsQueary = data.Dogs.AsQueryable();

            if (!string.IsNullOrWhiteSpace(breed))
            {
                dogsQueary = dogsQueary.Where(x =>
                     x.Breed.Breed == breed);
            }

            if (!string.IsNullOrWhiteSpace(gender))
            {
                dogsQueary = dogsQueary.Where(x => x.Gender == gender);
            }

            if (purpose != 0)
            {
                if (purpose == 1)
                {
                    dogsQueary = dogsQueary.Where(p => p.Purpose == (PetPurpose)1);
                }
                else if (purpose == 2)
                {
                    dogsQueary = dogsQueary.Where(p => p.Purpose == (PetPurpose)2);
                }
                else if (purpose == 3)
                {
                    dogsQueary = dogsQueary.Where(p => p.Purpose == (PetPurpose)3);
                }
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                dogsQueary = dogsQueary.Where(x =>
                (x.Breed.Breed + " " + x.Gender).ToLower().Contains(searchTerm.ToLower()) ||
                x.Comment.ToLower().Contains(searchTerm.ToLower()));
            }
            dogsQueary = sorting switch
            {
                PetSorting.Age => dogsQueary.OrderBy(x => x.Age),
                PetSorting.DateCreated => dogsQueary.OrderByDescending(x => x.Id),
                PetSorting.Price => dogsQueary.OrderBy(x => x.Price)
            };

            var dogsCount = dogsQueary.Count();

            var dogs = dogsQueary
                .Skip((currentPage - 1) * AllPetsQueryModel.PetsPerPage)
                .Take(AllPetsQueryModel.PetsPerPage)
                .Select(x => new PetsListingServiceModel
                {
                    Id = x.Id,
                    Breed = x.Breed.Breed,
                    Name = x.Name,
                    Purpose = x.Purpose,
                    Price = x.Price,
                    Age = x.Age,
                    Gender = x.Gender,
                    Picture = x.PictureUrl
                }).ToList();

            return new PetsQueryServiceModel
            {
                CurrentPage = currentPage,
                PetsPerPage = petsPerPage,
                TotalPets = dogsQueary.Count(),
                Pets = dogs
            };
        }

        public int AddDog(
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
            var dog = new Dog
            {
                DogBreedId = breedId,
                Gender = gender,
                Age = age,
                Name = name,
                Purpose = (PetPurpose)purpose,
                Price = price,
                PictureUrl = pictureUrl,
                Comment = comment,
                UserId = userId
            };

            data.Dogs.Add(dog);
            data.SaveChanges();

            return dog.Id;
        }

        public IEnumerable<PetsBreedServiceModel> GetDogBreeds()
        {
            return data.DogBreeds.Select(x => new PetsBreedServiceModel
            {
                Id = x.Id,
                Breed = x.Breed

            }).ToList();
        }


    }
}

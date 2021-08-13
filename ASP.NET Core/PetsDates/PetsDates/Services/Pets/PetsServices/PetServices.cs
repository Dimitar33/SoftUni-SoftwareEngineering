using PetsDates.Data;
using PetsDates.Data.Models;
using PetsDates.Data.Models.Dogs;
using PetsDates.Models.Pets;
using PetsDates.Services.Pets;
using PetsDates.Services.Pets.PetsServices;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PetDates.Services.Pets.PetServices
{
    public class PetServices : IPetServices
    {
        private readonly PetsDatesDbContext data;

        public PetServices(PetsDatesDbContext data)
        {
            this.data = data;
        }

        public PetsQueryServiceModel AllPets(
           string breed,
           string gender,
           int purpose,
           string searchTerm,
           PetSorting sorting,
           int currentPage,
           int petsPerPage)
        {
            var stakTrace = new StackTrace();
            var caller = stakTrace.GetFrame(1).GetMethod().Name;

            IQueryable<Pet> petsQuery;

            if (caller == "AllDogs")
            {
                petsQuery = data.Dogs.AsQueryable();
            }
            else
            {
                petsQuery = data.Cats.AsQueryable();
            }

            if (!string.IsNullOrWhiteSpace(breed))
            {
                petsQuery = petsQuery.Where(x =>
                     x.Breed.Name == breed);
            }

            if (!string.IsNullOrWhiteSpace(gender))
            {
                petsQuery = petsQuery.Where(x => x.Gender == gender);
            }

            petsQuery = purpose switch
            {
                1 => petsQuery.Where(p => p.Purpose == (PetPurpose)1),
                2 => petsQuery.Where(p => p.Purpose == (PetPurpose)2),
                3 => petsQuery.Where(p => p.Purpose == (PetPurpose)3),
                _ => petsQuery
            };

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                petsQuery = petsQuery.Where(x =>
                (x.Breed.Name + " " + x.Gender).ToLower().Contains(searchTerm.ToLower()) ||
                x.Comment.ToLower().Contains(searchTerm.ToLower()));
            }
            petsQuery = sorting switch
            {
                PetSorting.Age => petsQuery.OrderBy(x => x.Age),
                PetSorting.DateCreated => petsQuery.OrderByDescending(x => x.Id),
                PetSorting.Price => petsQuery.OrderBy(x => x.Price),
                _ => petsQuery
            };

            var dogsCount = petsQuery.Count();

            var pets = petsQuery
                .Skip((currentPage - 1) * AllPetsQueryModel.PetsPerPage)
                .Take(AllPetsQueryModel.PetsPerPage)
                .Select(x => new PetsListingServiceModel
                {
                    Id = x.Id,
                    Breed = x.Breed.Name,
                    Name = x.Name,
                    Purpose = x.Purpose,
                    Price = x.Price,
                    Age = x.Age,
                    Gender = x.Gender,
                    PictureUrl = x.PictureUrl
                }).ToList();

            return new PetsQueryServiceModel
            {
                CurrentPage = currentPage,
                PetsPerPage = petsPerPage,
                TotalPets = petsQuery.Count(),
                Pets = pets
            };
        }
        public IEnumerable<PetsBreedServiceModel> GetBreeds(int id)
        {
            var pet = data.Pets.FirstOrDefault(x => x.Id == id);

            if (pet is Dog)
            {
                return GetDogBreeds();
            }

            return GetCatBreeds();
        }
        public IEnumerable<PetsBreedServiceModel> GetDogBreeds()
        {
            return data.DogBreeds.Select(x => new PetsBreedServiceModel
            {
                Id = x.Id,
                Breed = x.Name

            }).OrderBy(x => x.Breed).ToList();
        }
        public IEnumerable<PetsBreedServiceModel> GetCatBreeds()
        {
            return data.CatBreeds.Select(x => new PetsBreedServiceModel
            {
                Id = x.Id,
                Breed = x.Name

            }).OrderBy(x => x.Breed).ToList();
        }
        public bool Edit(
            int id,
            int breed,
            string gender,
            string name,
            int purpose,
            double? price,
            double? age,
            string picture,
            string comment
            )
        {
            var pet = data.Pets.FirstOrDefault(x => x.Id == id);

            if (pet == null)
            {
                return false;
            }

            pet.Name = name;
            pet.Gender = gender;
            pet.BreedId = breed;
            pet.PictureUrl = picture;
            pet.Purpose = (PetPurpose)purpose;
            pet.Price = price;
            pet.Age = age;
            pet.Comment = comment;

            data.SaveChanges();

            return true;
        }
        public PetsDetailsServiceModel Details(int id)
        {
            return data.Pets
           .Where(x => x.Id == id)
           .Select(x => new PetsDetailsServiceModel
           {
               Id = x.Id,
               BreedId = x.BreedId,
               Breed = x.Breed.Name,
               Gender = x.Gender,
               Age = x.Age,
               Name = x.Name,
               Purpose = x.Purpose,
               PictureUrl = x.PictureUrl,
               Price = x.Price,
               Email = x.Owner.Email,
               PhoneNumber = x.Owner.PhoneNumber,
               OwnerId = x.Owner.Id,
               OwnerName = x.Owner.UserName,
               Comment = x.Comment,

           }).FirstOrDefault();
        }
        public void Delete(int id)
        {
            var pet = data.Pets.FirstOrDefault(x => x.Id == id);

            data.Pets.Remove(pet);
            data.SaveChanges();
        }
    }
}

using PetsDates.Data;
using PetsDates.Data.Models;
using PetsDates.Models.Pets;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetsDates.Services.Pets
{
    public class PetsServices : IPetsServices
    {
        private readonly PetsDatesDbContext data;

        public PetsServices(PetsDatesDbContext data)
        {
            this.data = data;
        }

        public PetsQueryServiceModel AllCats(
            string breed,
            string gender,
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

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                catsQueary = catsQueary.Where(x =>
                (x.Breed.Breed + " " + x.Gender).ToLower().Contains(searchTerm.ToLower()) ||
                x.Comment.ToLower().Contains(searchTerm.ToLower()));
            }
            catsQueary = sorting switch
            {
                PetSorting.Age => catsQueary.OrderBy(x => x.Age),
                PetSorting.DateCreated => catsQueary.OrderByDescending(x => x.Id)
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

        public PetsQueryServiceModel AllDogs(
           string breed,
           string gender,
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

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                dogsQueary = dogsQueary.Where(x =>
                (x.Breed.Breed + " " + x.Gender).ToLower().Contains(searchTerm.ToLower()) ||
                x.Comment.ToLower().Contains(searchTerm.ToLower()));
            }
            dogsQueary = sorting switch
            {
                PetSorting.Age => dogsQueary.OrderBy(x => x.Age),
                PetSorting.DateCreated => dogsQueary.OrderByDescending(x => x.Id)
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

        public int AddCat(
            int breedId, 
            string gender, 
            double? age,
            string name,
            string pictureUrl,
            string comment,
            string userId)
        {
            var cat = new Cat
            {
                CatBreedId = breedId,
                Gender = gender,
                Age = age,
                PictureUrl = pictureUrl,
                Comment = comment,
                Name = name,
                UserId = userId
            };

            data.Cats.Add(cat);
            data.SaveChanges();

            return cat.Id;
        }

        public int AddDog(
          int breedId,
          string gender,
          double? age,
          string name,
          string pictureUrl,
          string comment,
          string userId)
        {
            var dog = new Dog
            {
                DogBreedId = breedId,
                Gender = gender,
                Age = age,
                PictureUrl = pictureUrl,
                Comment = comment,
                Name = name,
                UserId = userId
            };

            data.Dogs.Add(dog);
            data.SaveChanges();

            return dog.Id;
        }
        public IEnumerable<PetsBreedServiceModel> GetCatBreeds()
        {
            return data.CatBreeds.Select(x => new PetsBreedServiceModel
            {
                Id = x.Id,
                Breed = x.Breed

            }).OrderBy(x => x.Breed).ToList();
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

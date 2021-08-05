﻿using PetsDates.Data;
using PetsDates.Data.Models;
using PetsDates.Data.Models.Dogs;
using PetsDates.Models.Pets;
using PetsDates.Services.Pets;
using PetsDates.Services.Pets.PetsServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

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
                    Picture = x.PictureUrl
                }).ToList();

            return new PetsQueryServiceModel
            {
                CurrentPage = currentPage,
                PetsPerPage = petsPerPage,
                TotalPets = petsQuery.Count(),
                Pets = pets
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
                Breed = x.Name

            }).OrderBy(x => x.Breed).ToList();
        }
    }
}

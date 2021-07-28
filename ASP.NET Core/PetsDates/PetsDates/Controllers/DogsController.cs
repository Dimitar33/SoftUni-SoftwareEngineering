using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetsDates.Data;
using PetsDates.Data.Models;
using PetsDates.Models.Pets;
using System.Collections.Generic;
using System.Linq;

namespace PetsDates.Controllers
{
    public class DogsController : Controller
    {
        private readonly PetsDatesDbContext data;

        public DogsController(PetsDatesDbContext data)
        {
            this.data = data;
        }

        public IActionResult AllDogs([FromQuery]AllPetsQueryModel query)
        {
            var dogsQuery = data.Dogs.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Breed))
            {
                dogsQuery = dogsQuery.Where(x => x.Breed.Breed == query.Breed);
            }

            if (!string.IsNullOrWhiteSpace(query.Gender))
            {
                dogsQuery = dogsQuery.Where(x => x.Gender == query.Gender);
            }

            dogsQuery = query.Sorting switch
            {
                PetSorting.DateCreated => dogsQuery
                        .OrderByDescending(x => x.Id),
                PetSorting.Age => dogsQuery.OrderBy(x => x.Age)
            };

            if (!string.IsNullOrWhiteSpace(query.SearchTerm))
            {
                dogsQuery = dogsQuery.Where(x =>
                (x.Breed.Breed + " " + x.Gender + " " + x.Age)
                .ToLower()
                .Contains(query.SearchTerm.ToLower()) || 
                x.Comment.ToLower().Contains(query.SearchTerm.ToLower()));
            }

            var dogsCount = dogsQuery.Count();

            var dogs = dogsQuery
                .Skip((query.CurrentPage - 1) * AllPetsQueryModel.PetsPerPage)
                .Take(AllPetsQueryModel.PetsPerPage)
                .Select(x => new PetsListingViewModel
            {
                Id = x.Id,
                Breed = x.Breed.Breed,
                Gender = x.Gender,
                Name = x.Name,
                Age = x.Age,
                Picture = x.PictureUrl
            });


            query.AllDogsCount = dogsCount;
            query.Breeds = GetDogBreeds().OrderBy(x => x.Breed);
            query.AllPets = dogs;

            return View(query);
        }

        [Authorize]
        public IActionResult AddDog()
        {
            return View(new AddPetViewModel
            {
                Breeds = GetDogBreeds().OrderBy(x => x.Breed)
            });
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddDog(AddPetViewModel dog)
        {
            if (!ModelState.IsValid)
            {
                dog.Breeds = GetDogBreeds().OrderBy(x => x.Breed);

                return View(dog);
            }

            var curentDog = new Dog
            {
                Name = dog.Name,
                Age = dog.Age,
                DogBreedId = dog.BreedId,
                Gender = dog.Gender,
                PictureUrl = dog.PictureUrl,
                Comment = dog.Comment,
            };

            data.Dogs.Add(curentDog);
            data.SaveChanges();

            return RedirectToAction(nameof(AddDog));
        }

        private IEnumerable<PetBreedViewModel> GetDogBreeds()
        {
            return data.DogBreeds.Select(x => new PetBreedViewModel
            {
                Id = x.Id,
                Breed = x.Breed

            }).ToList();
        }
    }
}

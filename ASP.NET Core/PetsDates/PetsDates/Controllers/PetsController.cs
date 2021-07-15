using Microsoft.AspNetCore.Mvc;
using PetsDates.Data;
using PetsDates.Data.Models;
using PetsDates.Models.Cats;
using PetsDates.Models.Dogs;
using System.Collections.Generic;
using System.Linq;

namespace PetsDates.Controllers
{
    public class PetsController : Controller
    {
        private readonly PetsDatesDbContext data;

        public PetsController(PetsDatesDbContext data)
        {
            this.data = data;
        }

        public IActionResult AddDog()
        {
            return View(new AddDogViewModel
            {
                Breeds = GetDogBreeds().OrderBy(x => x.Breed)
            });
        }

        [HttpPost]
        public IActionResult AddDog(AddDogViewModel dog)
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

        public IActionResult AddCat()
        {
            return View(new AddCatViewModel
            {
                Breeds = GetCatBreeds().OrderBy(x => x.Breed)
            });
        }

        [HttpPost]
        public IActionResult AddCat(AddCatViewModel cat)
        {
            if (!ModelState.IsValid)
            {
                cat.Breeds = GetCatBreeds().OrderBy(x => x.Breed);

                return View(cat);
            }

            var curentCat = new Cat
            {
                CatBreedId = cat.BreedId,
                Name = cat.Name,
                Age = cat.Age,
                Gender = cat.Gender,
                PictureUrl = cat.PictureUrl,
                Comment = cat.Comment,
            };

            data.Cats.Add(curentCat);
            data.SaveChanges();

            return RedirectToAction(nameof(AddCat));
        }




        private IEnumerable<CatBreedViewModel> GetCatBreeds()
        {
            return data.CatBreeds.Select(x => new CatBreedViewModel
            {
                Id = x.Id,
                Breed = x.Breed

            }).ToList();
        }

        private IEnumerable<DogBreedViewModel> GetDogBreeds()
        {
            return data.DogBreeds.Select(x => new DogBreedViewModel
            {
                Id = x.Id,
                Breed = x.Breed

            }).ToList();
        }
    }
}

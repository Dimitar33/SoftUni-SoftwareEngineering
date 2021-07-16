using Microsoft.AspNetCore.Mvc;
using PetsDates.Data;
using PetsDates.Data.Models;
using PetsDates.Models.Dogs;
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

        public IActionResult AllDogs()
        {
            return View();
        }

        public IActionResult AddDog()
        {
            return View(new AddPetViewModel
            {
                Breeds = GetDogBreeds().OrderBy(x => x.Breed)
            });
        }

        [HttpPost]
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

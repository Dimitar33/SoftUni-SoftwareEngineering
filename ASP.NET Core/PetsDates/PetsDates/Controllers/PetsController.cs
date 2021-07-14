using Microsoft.AspNetCore.Mvc;
using PetsDates.Data;
using PetsDates.Models.Dogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                Breed = GetDogBreeds()
            }); 
        }

        [HttpPost]
        public IActionResult AddDog(AddDogViewModel dog)
        {


            return View();
        }

        public IActionResult AddCat()
        {
            return View();
        }

        private IEnumerable<DogBreedViewModel> GetDogBreeds()
        {
            return data.DogBreeds.Select(x => new DogBreedViewModel
            {
                Id = x.Id,
                Name = x.Name
            });
        }
    }
}

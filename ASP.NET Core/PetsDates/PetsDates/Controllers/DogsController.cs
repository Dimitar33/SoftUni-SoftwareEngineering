using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetsDates.Data;
using PetsDates.Data.Models;
using PetsDates.Models.Pets;
using PetsDates.Services.Pets;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace PetsDates.Controllers
{
    public class DogsController : Controller
    {
        private readonly IPetsServices petsServices;

        public DogsController(IPetsServices petsServices)
        {
            this.petsServices = petsServices;
        }

        public IActionResult AllDogs([FromQuery] AllPetsQueryModel query)
        {

            var dogsQueri = petsServices.AllDogs(
                query.Breed,
                query.Gender,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                AllPetsQueryModel.PetsPerPage);

            query.AllDogsCount = dogsQueri.TotalPets;
            query.Breeds = petsServices.GetDogBreeds();
            query.AllPets = dogsQueri.Pets;

            return View(query);
        }

        [Authorize]
        public IActionResult AddDog()
        {
            return View(new AddPetViewModel
            {
                Breeds = petsServices.GetDogBreeds()
            });
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddDog(AddPetViewModel dog)
        {
            if (!ModelState.IsValid)
            {
                dog.Breeds = petsServices.GetDogBreeds();

                return View(dog);
            }

            var ownerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            petsServices.AddDog(
                dog.BreedId,
                dog.Gender,
                dog.Age,
                dog.Name,
                dog.PictureUrl,
                dog.Comment,
                ownerId);

            return RedirectToAction(nameof(AddDog));
        }


    }
}

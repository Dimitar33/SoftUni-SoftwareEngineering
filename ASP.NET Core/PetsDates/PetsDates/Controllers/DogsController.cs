using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetsDates.Models.Pets;
using PetsDates.Services.Pets.DogsServices;
using System.Security.Claims;

namespace PetsDates.Controllers
{
    public class DogsController : Controller
    {
        private readonly IDogServices dogServices;

        public DogsController(IDogServices petsServices)
        {
            this.dogServices = petsServices;
        }

        public IActionResult AllDogs([FromQuery] AllPetsQueryModel query)
        {

            var dogsQueri = dogServices.AllDogs(
                query.Breed,
                query.Gender,
                query.Purpose,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                AllPetsQueryModel.PetsPerPage);

            query.AllDogsCount = dogsQueri.TotalPets;
            query.Breeds = dogServices.GetDogBreeds();
            query.AllPets = dogsQueri.Pets;

            return View(query);
        }

        [Authorize]
        public IActionResult AddDog()
        {
            return View(new AddPetViewModel
            {
                Breeds = dogServices.GetDogBreeds()
            });
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddDog(AddPetViewModel dog)
        {
            if (!ModelState.IsValid)
            {
                dog.Breeds = dogServices.GetDogBreeds();

                return View(dog);
            }

            var ownerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            dogServices.AddDog(
                dog.BreedId,
                dog.Gender,
                dog.Age,
                dog.Name,
                dog.Purpose,
                dog.Price,
                dog.PictureUrl,
                dog.Comment,
                ownerId);

            return RedirectToAction(nameof(AddDog));
        }


    }
}

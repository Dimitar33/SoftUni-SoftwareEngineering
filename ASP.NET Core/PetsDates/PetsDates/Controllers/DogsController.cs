using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetsDates.Models.Home;
using PetsDates.Models.Pets;
using PetsDates.Services.HomeServices;
using PetsDates.Services.Pets.DogsServices;
using System.Linq;
using System.Security.Claims;

namespace PetsDates.Controllers
{
    public class DogsController : Controller
    {
        private readonly IDogServices dogServices;
        private readonly IHomeService homeServices;

        public DogsController(IDogServices petsServices, IHomeService homeServices)
        {
            this.dogServices = petsServices;
            this.homeServices = homeServices;
        }

        public IActionResult Dogs()
        {
            var dogs = homeServices.DogsCarousel().ToList();

            return View(new IndexViewModel
            {
                Pets = dogs
            });
        }
        public IActionResult AllDogs([FromQuery] AllPetsQueryModel query)
        {

            var dogsQueri = dogServices.AllPets(
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

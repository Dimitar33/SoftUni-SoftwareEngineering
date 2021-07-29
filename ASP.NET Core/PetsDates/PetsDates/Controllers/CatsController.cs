using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetsDates.Data;
using PetsDates.Data.Models;
using PetsDates.Models.Pets;
using PetsDates.Services.Pets;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Security.Claims;

namespace PetsDates.Controllers
{
    public class CatsController : Controller
    {
        private readonly IPetsServices petServices;

        public CatsController( IPetsServices petServices)
        {     
            this.petServices = petServices;
        }

        public IActionResult AllCats([FromQuery]AllPetsQueryModel query)
        {
            var catsQuery = petServices.AllCats(
                query.Breed, 
                query.Gender, 
                query.SearchTerm, 
                query.Sorting, 
                query.CurrentPage, 
                AllPetsQueryModel.PetsPerPage);

            query.AllCatsCount = catsQuery.TotalPets;
            query.Breeds = petServices.GetCatBreeds().ToList();
            query.AllPets = catsQuery.Pets;

            return View(query);
        }

        [Authorize]
        public IActionResult AddCat()
        {
            return View(new AddPetViewModel
            {
                Breeds = petServices.GetCatBreeds()
            });
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddCat(AddPetViewModel cat)
        {
            if (!ModelState.IsValid)
            {
                cat.Breeds = petServices.GetCatBreeds();

                return View(cat);
            }

            var ownerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            this.petServices.AddCat(
                cat.BreedId,
                cat.Gender,
                cat.Age,
                cat.Name,
                cat.PictureUrl,
                cat.Comment,
                ownerId);    

            return RedirectToAction(nameof(AllCats));
        }

        
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetsDates.Models.Pets;
using PetsDates.Services.Pets.CatsServices;
using System.Linq;
using System.Security.Claims;

namespace PetsDates.Controllers
{
    public class CatsController : Controller
    {
        private readonly ICatServices catServices;

        public CatsController(ICatServices petServices)
        {     
            this.catServices = petServices;
        }

        public IActionResult AllCats([FromQuery]AllPetsQueryModel query)
        {
            var catsQuery = catServices.AllCats(
                query.Breed, 
                query.Gender, 
                query.Purpose,
                query.SearchTerm, 
                query.Sorting, 
                query.CurrentPage, 
                AllPetsQueryModel.PetsPerPage);

            query.AllCatsCount = catsQuery.TotalPets;
            query.Breeds = catServices.GetCatBreeds().ToList();
            query.AllPets = catsQuery.Pets;

            return View(query);
        }

        [Authorize]
        public IActionResult AddCat()
        {
            return View(new AddPetViewModel
            {
                Breeds = catServices.GetCatBreeds()
            });
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddCat(AddPetViewModel cat)
        {
            if (!ModelState.IsValid)
            {
                cat.Breeds = catServices.GetCatBreeds();

                return View(cat);
            }

            var ownerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            this.catServices.AddCat(
                cat.BreedId,
                cat.Gender,
                cat.Age,
                cat.Name,
                cat.Purpose,
                cat.Price,
                cat.PictureUrl,
                cat.Comment,
                ownerId);    

            return RedirectToAction(nameof(AllCats));
        }

        
    }
}

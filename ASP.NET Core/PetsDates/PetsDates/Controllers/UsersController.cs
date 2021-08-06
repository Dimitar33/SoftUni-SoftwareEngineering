using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PetsDates.Data.Models;
using PetsDates.Data.Models.Cats;
using PetsDates.Data.Models.Dogs;
using PetsDates.Models.Moderator;
using PetsDates.Models.Pets;
using PetsDates.Services.UsersServices;
using System.Security.Claims;

namespace PetsDates.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserServices userServices;

        public UsersController(IUserServices userServices, UserManager<User> userManager)
        {
            this.userServices = userServices;
        }

        [Authorize]
        public IActionResult MyPets()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var pets = userServices.PetsByUser(userId);

            return View(pets);
        }

        [Authorize]
        public IActionResult Mod()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Mod(ModFormModel modModel)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            if (!ModelState.IsValid)
            {
                return View();
            }

            userServices.AddToRole(userId);

            return RedirectToAction("Index", "Home");
        }


        [Authorize]
        public IActionResult Edit(int id)
        {
           // var pet = userServices.CatOrDog(id);

            //if (pet is Dog)
            //{
            //    return View();
            //}

            //else if (pet is Cat)
            //{

            //}

            return View("Error");
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(int id, AddPetViewModel petModel)
        {
            userServices.Edit(
                id,
                petModel.BreedId,
                petModel.Gender,
                petModel.Name,
                petModel.Purpose,
                petModel.Price,
                petModel.Age,
                petModel.PictureUrl);

            return View(nameof(MyPets));
        }

 
    }
}

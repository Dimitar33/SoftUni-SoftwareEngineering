using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetsDates.Models.Pets;
using PetsDates.Services.UsersServices;
using System.Security.Claims;

namespace PetsDates.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserServices userServices;

        public UsersController(IUserServices userServices)
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
        public IActionResult Edit()
        {
            return View();
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

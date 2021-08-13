using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PetsDates.Data.Models;
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
        public IActionResult Mod(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            userServices.AddToRole(userId);
            
            SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}

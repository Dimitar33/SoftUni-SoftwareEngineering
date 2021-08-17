using Microsoft.AspNetCore.Mvc;
using PetsDates.Services.UsersServices;

namespace PetsDates.Areas.Administration.Controllers
{
    public class UsersController : AdminController
    {
        private readonly IUserServices userServices;

        public UsersController(IUserServices userServices)
        {
            this.userServices = userServices;
        }

        public IActionResult AllUsers()
        {
            var users = userServices.AllUsers();

            return View(users);
        }

        public IActionResult GiveMod(string username)
        {
            userServices.GiveMod(username);

            return RedirectToAction(nameof(AllUsers));
        }

        public IActionResult RemoveMod(string username)
        {
            userServices.RemoveMod(username);

            return RedirectToAction(nameof(AllUsers));
        }
    }
}

using BusinessLogic.Services.Interfaces;
using BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;
using University.Models;

namespace University.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly IUserServices userServices;
        public AdministrationController(IUserServices us)
        {
            this.userServices = us;
        }

        public IActionResult Users()
        {
            var users = userServices.GetAllUsers();

            return View(users);
        }

        public IActionResult AddRole(int id)
        {
            userServices.Addrole(id, "asd");

            return View();
        }
        public IActionResult OperatorDetails(int id)
        {
            var user = this.userServices.GetUser(id);

            return View(user);
        }
        public IActionResult Details(int id)
        {
            var user = this.userServices.GetUser(id);

            return View(user);
        }
        public IActionResult Administrators()
        {
            var admins = userServices.GetAdmins();

            return View(admins);
        }

        public IActionResult Operators()
        {
            var operators = userServices.GetOperators();

            return View(operators);
        }

        public IActionResult Moderate()
        {
            var users = userServices.GetAllUsers()
                .Where(x => !x.Role.Contains("Administrator")).ToList();

            return View(users);
        }

        
        public IActionResult CreateAdmin()
        {
            return View(new UserViewModel());
        }

        [HttpPost]
        public IActionResult CreateAdmin(UserViewModel model)
        {

            //if (!ModelState.IsValid)
            //{
            //    var errors = ModelState.Values.SelectMany(x => x.Errors);
            //    return View(errors);
            //}

            userServices.AddUser(model, "Administrator");

            var admins = userServices.GetAdmins();

            return View("Administrators", admins);
        }
        public IActionResult CreateOperator()
        {
            return View(new UserViewModel());
        }

        [HttpPost]
        public IActionResult CreateOperator(UserViewModel model)
        {

            //if (!ModelState.IsValid)
            //{
            //    var errors = ModelState.Values.SelectMany(x => x.Errors);
            //    return View(errors);
            //}

            userServices.AddUser(model, "Operator");

            var oeprators = userServices.GetOperators();

            return View("Operators", oeprators);
        }

        public IActionResult EditUser(int id)
        {
            var user = userServices.GetUser(id);

            return View(user);
        }

        [HttpPost]
        public IActionResult EditUser(int id, UserViewModel model)
        {

            userServices.EditUser(id, model);
            var users = userServices.GetAllUsers()
                .Where(x => !x.Role.Contains("Administrator")).ToList();

            return RedirectToAction("Moderate", "Administration", users);
        }
        public void Delete(int id)
        {
            userServices.DeleteUser(id);

        }
    }
}

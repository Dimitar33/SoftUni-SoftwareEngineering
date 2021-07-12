using MyWebServer.Controllers;
using MyWebServer.Http;
using SharedTrip.Data;
using SharedTrip.Models;
using SharedTrip.Models.ViewModels.UserViewModels;
using SharedTrip.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext data;

        private readonly IValidator validator;

        private readonly IPasswordHasher hasher;

        public UsersController(
            ApplicationDbContext data, 
            IValidator validator, 
            IPasswordHasher hasher)
        {
            this.data = data;
            this.validator = validator;
            this.hasher = hasher;
        }

        public HttpResponse Register() => View();
        
        [HttpPost]
        public HttpResponse Register(UsersRegisterViewModel model)
        {
            var errors = validator.ValidateUser(model);

            if (errors.Count > 0)
            {
                return Error(errors);
            }

            var user = new User
            {
                Username = model.Username,
                Email = model.Email,
                Password = hasher.HashPassword(model.Password),
            };

            data.Users.Add(user);
            data.SaveChanges();

            return Redirect("Login");
        }
        public HttpResponse Login() => View();

        [HttpPost]
        public HttpResponse Login(UsersLoginViewModel model)
        {
            var password = hasher.HashPassword(model.Password);

            var user = data.Users.FirstOrDefault(x => x.Username == model.Username && x.Password == password);

            if (user == null)
            {
                return Error("Invalid username or password");
            }

            SignIn(user.Id);

            return Redirect("/Trips/All");
        }

        public HttpResponse Logout()
        {
            SignOut();

            return Redirect("/");
        }
    }
}

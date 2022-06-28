using Invest_Team_Ltd.___ASP.NET_Web_API___jQuery_Assignment.Data;
using Invest_Team_Ltd.___ASP.NET_Web_API___jQuery_Assignment.Models;
using Invest_Team_Ltd.___ASP.NET_Web_API___jQuery_Assignment.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invest_Team_Ltd.___ASP.NET_Web_API___jQuery_Assignment.Controllers
{
    [ApiController]
    [Route("Users")]
    public class UsersController : ControllerBase
    {

        private readonly AppDbContext data;

        public UsersController(AppDbContext db)
        {
            data = db;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return data.Users.ToList();
        }

        [HttpPost]
        public User Post(UserViewModel userModel)
        {
            var user = new User
            {
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Email = userModel.Email,
                Password = userModel.Password,
                Role = userModel.Role
            };

            data.Users.Add(user);
            data.SaveChanges();

            return user;
        }

        [HttpPut("{id}")]
        public User Put(UserViewModel userModel, int id)
        {
            var user = data.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return null;
            }

            user.FirstName = userModel.FirstName;
            user.LastName = userModel.LastName;
            user.Email = userModel.Email;
            user.Password = userModel.Password;
            user.Role = userModel.Role;

            data.SaveChanges();

            return user;
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            var user = data.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return "No such user";
            }

            data.Users.Remove(user);
            data.SaveChanges();

            return "User successfully deleted";
        }
    }
}

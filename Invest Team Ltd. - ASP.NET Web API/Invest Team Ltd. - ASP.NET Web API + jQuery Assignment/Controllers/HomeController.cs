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
    [Route("Home")]
    public class HomeController : ControllerBase
    {
        private readonly AppDbContext data;

        public HomeController(AppDbContext db)
        {
            data = db;
        }

        [HttpPost]
        public  User Login(LoginViewModel userModel)
        {
            var user = data.Users.FirstOrDefault(x => 
                    x.Email == userModel.Email &&           
                    x.Password == userModel.Password);

            if (user == null)
            {
                return null;
            }

            return user;
        }
    }
}

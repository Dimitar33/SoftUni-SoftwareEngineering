using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetsDates.Controllers
{
    public class PetsController : Controller
    {
        public IActionResult AddDog()
        {
            return View();
        }

        public IActionResult AddCat()
        {
            return View();
        }
    }
}

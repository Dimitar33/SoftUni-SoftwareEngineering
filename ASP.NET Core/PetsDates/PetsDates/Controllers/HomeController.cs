using Microsoft.AspNetCore.Mvc;
using PetsDates.Models;
using PetsDates.Models.Home;
using PetsDates.Services.HomeServices;
using PetsDates.Services.Pets;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PetsDates.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService homeServices;

        public HomeController(IHomeService homeServices)
        {
            this.homeServices = homeServices;
        }

        public IActionResult Index()
        {
            var cats = homeServices.CatsCarousel().ToList();

            var dogs = homeServices.DogsCarousel().ToList();

            var pets = new List<PetsListingServiceModel>();
            var count = Math.Ceiling((double)(cats.Count() + dogs.Count()) / 2);

            for (int i = 0; i < count; i++)
            {
                if (i < cats.Count())
                {
                    pets.Add(cats[i]);
                }
                if (i < dogs.Count())
                {
                    pets.Add(dogs[i]);
                }
            }

            return View(new IndexViewModel
            {
                Pets = pets
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

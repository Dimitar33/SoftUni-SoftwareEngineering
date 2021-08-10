using Microsoft.AspNetCore.Mvc;
using PetsDates.Data;
using PetsDates.Models;
using PetsDates.Models.Home;
using PetsDates.Models.Pets;
using PetsDates.Services.Pets;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PetsDates.Controllers
{
    public class HomeController : Controller
    {
        private readonly PetsDatesDbContext data;

        public HomeController(PetsDatesDbContext data)
        {
            this.data = data;
        }

        public IActionResult Index()
        {
            var cats = data.Cats
                .OrderByDescending(x => x.Id)
                .Take(3)
                .Select(x => new PetsListingServiceModel
                {
                    Id = x.Id,
                    Breed = x.Breed.Name,
                    Age = x.Age,
                    Gender = x.Gender,
                    Name = x.Name,
                    PictureUrl = x.PictureUrl
                }).ToList();

            var dogs = data.Dogs
                .OrderByDescending(x => x.Id)
                .Take(3)
                .Select(x => new PetsListingServiceModel
                {
                    Id = x.Id,
                    Breed = x.Breed.Name,
                    Age = x.Age,
                    Gender = x.Gender,
                    Name = x.Name,
                    PictureUrl = x.PictureUrl
                }).ToList();

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

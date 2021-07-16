﻿using Microsoft.AspNetCore.Mvc;
using PetsDates.Data;
using PetsDates.Data.Models;
using PetsDates.Models.Pets;
using System.Collections.Generic;
using System.Linq;

namespace PetsDates.Controllers
{
    public class CatsController : Controller
    {

        private readonly PetsDatesDbContext data;

        public CatsController(PetsDatesDbContext data)
        {
            this.data = data;
        }

        public IActionResult AllCats([FromQuery]AllPetsQueryModel query)
        {
            var catsQueary = data.Cats.AsQueryable();

            var cats
                = catsQueary.Select(x => new PetsListingViewModel
            {
                Id = x.Id,
                Breed = x.Breed.Breed,
                Name = x.Name,
                Age = x.Age,
                Gender = x.Gender,
                Picture = x.PictureUrl
            }).ToList();

            query.AllPets = cats;

            return View(query);
        }


        public IActionResult AddCat()
        {
            return View(new AddPetViewModel
            {
                Breeds = GetCatBreeds().OrderBy(x => x.Breed)
            });
        }

        [HttpPost]
        public IActionResult AddCat(AddPetViewModel cat)
        {
            if (!ModelState.IsValid)
            {
                cat.Breeds = GetCatBreeds().OrderBy(x => x.Breed);

                return View(cat);
            }

            var curentCat = new Cat
            {
                CatBreedId = cat.BreedId,
                Name = cat.Name,
                Age = cat.Age,
                Gender = cat.Gender,
                PictureUrl = cat.PictureUrl,
                Comment = cat.Comment,
            };

            data.Cats.Add(curentCat);
            data.SaveChanges();

            return RedirectToAction(nameof(AddCat));
        }

        private IEnumerable<PetBreedViewModel> GetCatBreeds()
        {
            return data.CatBreeds.Select(x => new PetBreedViewModel
            {
                Id = x.Id,
                Breed = x.Breed

            }).ToList();
        }
    }
}
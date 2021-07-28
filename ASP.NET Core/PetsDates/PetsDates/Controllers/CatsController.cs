using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

            if (!string.IsNullOrWhiteSpace(query.Breed))
            {
                catsQueary = catsQueary.Where(x => 
                     x.Breed.Breed == query.Breed);
            }

            if (!string.IsNullOrWhiteSpace(query.Gender))
            {
                catsQueary = catsQueary.Where(x => x.Gender == query.Gender);
            }

            if (!string.IsNullOrWhiteSpace(query.SearchTerm))
            {
                catsQueary = catsQueary.Where(x =>
                (x.Breed.Breed + " " + x.Gender).ToLower().Contains(query.SearchTerm.ToLower()) || 
                x.Comment.ToLower().Contains(query.SearchTerm.ToLower()));
            }
            catsQueary = query.Sorting switch
            {
                PetSorting.Age => catsQueary.OrderBy(x => x.Age),
                PetSorting.DateCreated => catsQueary.OrderByDescending(x => x.Id)
            };

            var catsCount = catsQueary.Count();

            var cats = catsQueary
                .Skip((query.CurrentPage - 1) * AllPetsQueryModel.PetsPerPage)
                .Take(AllPetsQueryModel.PetsPerPage)
                .Select(x => new PetsListingViewModel
            {
                Id = x.Id,
                Breed = x.Breed.Breed,
                Name = x.Name,
                Age = x.Age,
                Gender = x.Gender,
                Picture = x.PictureUrl
            }).ToList();

            query.AllCatsCount = catsCount;
            query.Breeds = GetCatBreeds().OrderBy(x => x.Breed);
            query.AllPets = cats;

            return View(query);
        }

        [Authorize]
        public IActionResult AddCat()
        {
            return View(new AddPetViewModel
            {
                Breeds = GetCatBreeds().OrderBy(x => x.Breed)
            });
        }

        [HttpPost]
        [Authorize]
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

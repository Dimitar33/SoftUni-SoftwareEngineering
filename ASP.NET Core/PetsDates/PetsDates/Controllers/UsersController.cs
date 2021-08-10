using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PetsDates.Data.Models;
using PetsDates.Models.Moderator;
using PetsDates.Models.Pets;
using PetsDates.Services.Pets.PetsServices;
using PetsDates.Services.UsersServices;
using System.Security.Claims;

namespace PetsDates.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserServices userServices;
        private readonly IPetServices petServices;
        private readonly IMapper mapper;
        public UsersController(IUserServices userServices, UserManager<User> userManager, IPetServices petServices, IMapper mapper)
        {
            this.userServices = userServices;
            this.petServices = petServices;
            this.mapper = mapper;
        }

        [Authorize]
        public IActionResult MyPets()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var pets = userServices.PetsByUser(userId);

            return View(pets);
        }

        [Authorize]
        public IActionResult Mod()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Mod(ModFormModel modModel)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!ModelState.IsValid)
            {
                return View();
            }

            userServices.AddToRole(userId);

            return RedirectToAction("Index", "Home");
        }


        [Authorize]
        public IActionResult Edit(int id)
        {

            var pet = userServices.Details(id);

            var petModel = mapper.Map<AddPetViewModel>(pet);

            petModel.Breeds = petServices.GetBreeds(id);

            return View(petModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(int id, AddPetViewModel petModel)
        {
            if (!ModelState.IsValid)
            {
                petModel.Breeds = petServices.GetBreeds(id);
            }
            userServices.Edit(
                id,
                petModel.BreedId,
                petModel.Gender,
                petModel.Name,
                petModel.Purpose,
                petModel.Price,
                petModel.Age,
                petModel.PictureUrl);

            return View(nameof(MyPets));
        }


    }
}

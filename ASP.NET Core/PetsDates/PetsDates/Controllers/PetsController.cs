using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetsDates.Models.Pets;
using PetsDates.Services.Pets.PetsServices;
using PetsDates.Services.UsersServices;

namespace PetsDates.Controllers
{
    public class PetsController : Controller
    {
        private readonly IPetServices petsServices;
        private readonly IMapper mapper;
        public PetsController(IPetServices petsServices, IUserServices userServices, IMapper mapper)
        {
            this.petsServices = petsServices;
            this.mapper = mapper;
        }

        public IActionResult Details(int id)
        {
            var petsDetails = petsServices.Details(id);

            return View(petsDetails);
        }
        [Authorize]
        public IActionResult Edit(int id)
        {

            var pet = petsServices.Details(id);

            var petModel = mapper.Map<AddPetViewModel>(pet);

            petModel.Breeds = petsServices.GetBreeds(id);

            return View(petModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(int id, AddPetViewModel petModel)
        {
            if (!ModelState.IsValid)
            {
                petModel.Breeds = petsServices.GetBreeds(id);
            }
            petsServices.Edit(
                id,
                petModel.BreedId,
                petModel.Gender,
                petModel.Name,
                petModel.Purpose,
                petModel.Price,
                petModel.Age,
                petModel.PictureUrl,
                petModel.Comment);

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            petsServices.Delete(id);

            return RedirectToAction("Index", "Home");
        }
    }
}

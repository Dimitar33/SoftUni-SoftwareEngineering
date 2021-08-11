using Microsoft.AspNetCore.Identity;
using PetsDates.Data;
using PetsDates.Data.Models;
using PetsDates.Data.Models.Cats;
using PetsDates.Data.Models.Dogs;
using PetsDates.Services.Pets;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PetsDates.Data.DataConstants;

namespace PetsDates.Services.UsersServices
{
    public class UserServices : IUserServices
    {
        private readonly PetsDatesDbContext data;
        private readonly UserManager<User> userManager;

        public UserServices(PetsDatesDbContext data, UserManager<User> userManager)
        {
            this.data = data;
            this.userManager = userManager;
        }

        public IEnumerable<PetsListingServiceModel> PetsByUser(string userId)
        {
            var cats = ListPets(data.Cats.Where(x => x.UserId == userId));
            var dogs = ListPets(data.Dogs.Where(x => x.UserId == userId));

            return cats.Concat(dogs).OrderBy(x => x.Id);
        }

        public IEnumerable<PetsListingServiceModel> ListPets(IQueryable<Pet> pet)
        {
            return pet.Select(x => new PetsListingServiceModel
            {
                Id = x.Id,
                Age = x.Age,
                Breed = x.Breed.Name,
                Gender = x.Gender,
                Name = x.Name,
                PictureUrl = x.PictureUrl,
                Price = x.Price,
                Purpose = x.Purpose
            }).ToList();
        }
        public bool Edit(
            int id,
            int breed,
            string gender,
            string name,
            int purpose,
            double? price,
            double? age,
            string picture
            )
        {
            var pet = data.Pets.FirstOrDefault(x => x.Id == id);

            if (pet == null)
            {
                return false;
            }

            pet.Name = name;
            pet.Gender = gender;
            pet.BreedId = breed;
            pet.PictureUrl = picture;
            pet.Purpose = (PetPurpose)purpose;
            pet.Price = price;
            pet.Age = age;

            data.SaveChanges();

            return true;
        }
        public void AddToRole(string id)
        {
            var user = data.Users.Find(id);

            Task.Run(async () =>
            {
                await userManager.AddToRoleAsync(user, Mod);

            }).GetAwaiter().GetResult();
        }
        public PetsDetailsServiceModel Details(int id)
        {
            return data.Pets
           .Where(x => x.Id == id)
           .Select(x => new PetsDetailsServiceModel
           {
               Id = x.Id,
               BreedId = x.BreedId,
               Breed = x.Breed.Name,
               Gender = x.Gender,
               Age = x.Age,
               Name = x.Name,
               Purpose = x.Purpose,
               PictureUrl = x.PictureUrl,
               Price = x.Price,
               OwnerId = x.Owner.Id,
               FirstName = x.Owner.FirtsName,
               LastName = x.Owner.LastName,
               Comment = x.Comment,

           }).FirstOrDefault();
        }
        public void Delete(int id)
        {
            var pet = data.Pets.FirstOrDefault(x => x.Id == id);

            data.Pets.Remove(pet);
            data.SaveChanges();
        }
    }
}

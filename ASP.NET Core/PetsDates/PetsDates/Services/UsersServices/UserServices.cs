using Microsoft.AspNetCore.Identity;
using PetsDates.Data;
using PetsDates.Data.Models;
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
        public void AddToRole(string id)
        {
            var user = data.Users.Find(id);

            Task.Run(async () =>
            {
                await userManager.AddToRoleAsync(user, Mod);

            }).GetAwaiter().GetResult();
        }
    }
}

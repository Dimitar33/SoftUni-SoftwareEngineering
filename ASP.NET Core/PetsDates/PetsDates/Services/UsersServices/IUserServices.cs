using PetsDates.Areas.Administration.Models;
using PetsDates.Data.Models;
using PetsDates.Services.Pets;
using System.Collections.Generic;
using System.Linq;

namespace PetsDates.Services.UsersServices
{
    public interface IUserServices
    {
        public void GiveMod(string id);
        public void RemoveMod(string id);
        public IEnumerable<UserViewModel> AllUsers();
        public IEnumerable<PetsListingServiceModel> PetsByUser(string userId);

        public IEnumerable<PetsListingServiceModel> ListPets(IQueryable<Pet> pet);
    }
}

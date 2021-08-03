using PetsDates.Data.Models;
using PetsDates.Services.Pets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetsDates.Services.UsersServices
{
    public interface IUserServices
    {
        public IEnumerable<PetsListingServiceModel> PetsByUser(string userId);

        public IEnumerable<PetsListingServiceModel> ListPets(IQueryable<Pet> pet);
    }
}

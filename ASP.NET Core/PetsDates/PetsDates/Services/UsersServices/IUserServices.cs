using PetsDates.Data.Models;
using PetsDates.Services.Pets;
using PetsDates.Services.Pets.PetsServices;
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

        public bool Edit(
            int id,
            int breed,
            string gender,
            string name,
            int purpose,
            double? price,
            double? age,
            string picture
            );

        public Pet CatOrDog(int id);
    }

}

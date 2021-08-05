using PetsDates.Models.Pets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetsDates.Services.Pets.PetsServices
{
    public interface IPetServices
    {
        public PetsQueryServiceModel AllPets(
             string breed,
             string gender,
             int purpose,
             string searchTerm,
             PetSorting sorting,
             int currentPage,
             int petsPerPage);
    }
}

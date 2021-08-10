using PetsDates.Models.Pets;
using System.Collections.Generic;

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
        public IEnumerable<PetsBreedServiceModel> GetBreeds(int id);
        IEnumerable<PetsBreedServiceModel> GetDogBreeds();
        IEnumerable<PetsBreedServiceModel> GetCatBreeds();
    }
}

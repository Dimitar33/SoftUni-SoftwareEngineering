using PetsDates.Models.Pets;
using System.Collections.Generic;

namespace PetsDates.Services.Pets.PetsServices
{
    public interface IPetServices
    {
        public void Delete(int id);
        public PetsDetailsServiceModel Details(int id);
        public bool Edit(
           int id,
           int breed,
           string gender,
           string name,
           int purpose,
           double? price,
           double? age,
           string picture,
           string comment
           );
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

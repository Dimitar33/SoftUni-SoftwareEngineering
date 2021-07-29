using PetsDates.Models.Pets;
using System.Collections.Generic;

namespace PetsDates.Services.Pets
{
    public interface IPetsServices
    {
        PetsQueryServiceModel AllCats(
             string breed,
             string gender,
             string searchTerm,
             PetSorting sorting,
             int currentPage,
             int petsPerPage);

        PetsQueryServiceModel AllDogs(
            string breed,
            string gender,
            string searchTerm,
            PetSorting sorting,
            int currentPage,
            int petsPerPage);

        IEnumerable<PetsBreedServiceModel> GetCatBreeds();

        IEnumerable<PetsBreedServiceModel> GetDogBreeds();

        int AddCat(
           int breedId,
           string gender,
           double? age,
           string name,
           string pictureUrl,
           string comment,
           string userId);

        int AddDog(
          int breedId,
          string gender,
          double? age,
          string name,
          string pictureUrl,
          string comment,
          string userId);
    }
}

using PetsDates.Models.Pets;
using System.Collections.Generic;

namespace PetsDates.Services.Pets.DogsServices
{
    public interface IDogServices
    {
        PetsQueryServiceModel AllDogs(
              string breed,
              string gender,
              int purpose,
              string searchTerm,
              PetSorting sorting,
              int currentPage,
              int petsPerPage);

        IEnumerable<PetsBreedServiceModel> GetDogBreeds();


        int AddDog(
          int breedId,
          string gender,
          double? age,
          string name,
          int purpose,
          double? price,
          string pictureUrl,
          string comment,
          string userId);
    }
}

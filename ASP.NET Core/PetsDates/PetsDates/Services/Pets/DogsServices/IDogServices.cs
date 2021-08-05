using PetsDates.Models.Pets;
using PetsDates.Services.Pets.PetsServices;
using System.Collections.Generic;

namespace PetsDates.Services.Pets.DogsServices
{
    public interface IDogServices : IPetServices
    {
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

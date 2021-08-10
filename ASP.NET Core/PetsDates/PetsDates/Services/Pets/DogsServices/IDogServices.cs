using PetsDates.Services.Pets.PetsServices;

namespace PetsDates.Services.Pets.DogsServices
{
    public interface IDogServices : IPetServices
    {
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

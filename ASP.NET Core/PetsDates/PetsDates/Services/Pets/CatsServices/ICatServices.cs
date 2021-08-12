using PetsDates.Services.Pets.PetsServices;


namespace PetsDates.Services.Pets.CatsServices
{
    public interface ICatServices : IPetServices
    {
        int AddCat(
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

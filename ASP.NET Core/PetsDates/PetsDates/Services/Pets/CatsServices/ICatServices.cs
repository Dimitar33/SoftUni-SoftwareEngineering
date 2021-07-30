
using PetsDates.Models.Pets;
using System.Collections.Generic;


namespace PetsDates.Services.Pets.CatsServices
{
    public interface ICatServices
    {
        PetsQueryServiceModel AllCats(
                 string breed,
                 string gender,
                 int purpose,
                 string searchTerm,
                 PetSorting sorting,
                 int currentPage,
                 int petsPerPage);

        IEnumerable<PetsBreedServiceModel> GetCatBreeds();

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

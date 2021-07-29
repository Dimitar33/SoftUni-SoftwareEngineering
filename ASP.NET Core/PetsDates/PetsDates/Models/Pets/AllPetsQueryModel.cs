using PetsDates.Services.Pets;
using System.Collections.Generic;

namespace PetsDates.Models.Pets
{
    public class AllPetsQueryModel
    {
        public const int PetsPerPage = 2;
        public int CurrentPage { get; init; } = 1;
        public string Breed { get; set; }
        public string Gender { get; set; }
        public string SearchTerm { get; set; }
        public PetSorting Sorting { get; set; }
        public int AllCatsCount { get; set; }
        public int AllDogsCount{ get; set; }
        public IEnumerable<PetsListingServiceModel> AllPets { get; set; } 
            = new List<PetsListingServiceModel>();

        public IEnumerable<PetsBreedServiceModel> Breeds { get; set; }
            = new List<PetsBreedServiceModel>();
    }
}

using PetDates.Services.Pets.PetServices;
using PetsDates.Data;
using PetsDates.Data.Models;
using PetsDates.Data.Models.Dogs;

namespace PetsDates.Services.Pets.DogsServices
{
    public class DogServices : PetServices, IDogServices
    {
        private readonly PetsDatesDbContext data;

        public DogServices(PetsDatesDbContext data)
            :base(data)
        {
            this.data = data;
        }

        public int AddDog(
          int breedId,
          string gender,
          double? age,
          string name,
          int purpose,
          double? price,
          string pictureUrl,
          string comment,
          string userId)
        {
            var dog = new Dog
            {
                BreedId = breedId,
                Gender = gender,
                Age = age,
                Name = name,
                Purpose = (PetPurpose)purpose,
                Price = price,
                PictureUrl = pictureUrl,
                Comment = comment,
                UserId = userId
            };

            data.Dogs.Add(dog);
            data.SaveChanges();

            return dog.Id;
        }
    }
}

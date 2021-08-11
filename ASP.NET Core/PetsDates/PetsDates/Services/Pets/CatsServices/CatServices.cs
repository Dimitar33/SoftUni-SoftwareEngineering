using PetDates.Services.Pets.PetServices;
using PetsDates.Data;
using PetsDates.Data.Models;
using PetsDates.Data.Models.Cats;
using PetsDates.Models.Pets;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PetsDates.Services.Pets.CatsServices
{
    public class CatServices : PetServices, ICatServices
    {
        private readonly PetsDatesDbContext data;

        public CatServices(PetsDatesDbContext data)
            :base(data)
        {
            this.data = data;
        }
        public int AddCat(
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
            var cat = new Cat
            {
                BreedId = breedId,
                Gender = gender,
                Age = age,
                Purpose = (PetPurpose)purpose,
                Price = price,
                PictureUrl = pictureUrl,
                Comment = comment,
                Name = name,
                UserId = userId
            };

            data.Cats.Add(cat);
            data.SaveChanges();

            return cat.Id;
        }
    }
}

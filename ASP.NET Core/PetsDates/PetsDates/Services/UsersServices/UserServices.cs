using Microsoft.AspNetCore.Mvc;
using PetsDates.Data;
using PetsDates.Data.Models;
using PetsDates.Services.Pets;
using System.Collections.Generic;
using System.Linq;

namespace PetsDates.Services.UsersServices
{
    public class UserServices : IUserServices
    {
        private readonly PetsDatesDbContext data;

        public UserServices(PetsDatesDbContext data)
        {
            this.data = data;
        }

        public IEnumerable<PetsListingServiceModel> PetsByUser(string userId)
        {
            var cats = ListPets(data.Cats.Where(x => x.UserId == userId));
            var dogs = ListPets(data.Dogs.Where(x => x.UserId == userId));

            return cats.Concat(dogs).OrderBy(x => x.Id);
        }

        public IEnumerable<PetsListingServiceModel> ListPets(IQueryable<Pet> pet)
        {
            return pet.Select(x => new PetsListingServiceModel
            {
                Age = x.Age,
                Breed = x.Breed.Name,
                Gender = x.Gender,
                Name = x.Name,
                Picture = x.PictureUrl,
                Price = x.Price,
                Purpose = x.Purpose
            }).ToList();
        }
        public bool Edit(
            int id,
            int breed,
            string gender,
            string name,
            int purpose,
            double? price,
            double? age,
            string picture
            )
        {
            var pet = data.Pets.FirstOrDefault(x => x.Id == id);

            if (pet == null)
            {
                return false;
            }

            pet.Name = name;
            pet.Gender = gender;
            pet.Breed.Id = breed;
            pet.PictureUrl = picture;
            pet.Purpose = (PetPurpose)purpose;
            pet.Price = price;
            pet.Age = age;

            data.SaveChanges();

            return true;
        }
    }
}

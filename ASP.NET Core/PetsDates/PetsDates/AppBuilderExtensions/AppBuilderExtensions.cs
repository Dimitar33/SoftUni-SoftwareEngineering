using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PetsDates.Data;
using PetsDates.Data.Models;
using System.Linq;

namespace PetsDates.AppBuilderExtensions
{
    public static class AppBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();

            var data = scope.ServiceProvider.GetService<PetsDatesDbContext>();

            data.Database.Migrate();

            SeedCatBreeds(data);
            SeedDogBreeds(data);

            return app;
        }

        public static void SeedCatBreeds(PetsDatesDbContext data)
        {
            if (!data.CatBreeds.Any() && !data.DogBreeds.Any())
            {
                return;
            }

            data.CatBreeds.AddRange(new[]
            {
                new CatBreed { Breed = "Abyssinian Cat"},
                new CatBreed { Breed = "Balinese-Javanese Cat"},
                new CatBreed { Breed = "Bengal Cat"},
                new CatBreed { Breed = "Birman Cat"},
                new CatBreed { Breed = "Bombay Cat"},
                new CatBreed { Breed = "Burmese Cat"},
                new CatBreed { Breed = "Chartreux Cat"},
                new CatBreed { Breed = "Cornish Rex Cat"},
                new CatBreed { Breed = "Devon Rex Cat"},
                new CatBreed { Breed = "Egyptian Mau Cat"},
                new CatBreed { Breed = "Havana Brown Cat"},
                new CatBreed { Breed = "Himalayan Cat"},
                new CatBreed { Breed = "Maine Coon Cat"},
                new CatBreed { Breed = "Manx Cat"},
                new CatBreed { Breed = "Oriental Cat"},
                new CatBreed { Breed = "Persian Cat"},
                new CatBreed { Breed = "Peterbald Cat"},
                new CatBreed { Breed = "Ragdoll Cat"},
                new CatBreed { Breed = "Scottish Cat"},
                new CatBreed { Breed = "Siamese Cat"},
                new CatBreed { Breed = "Siberian Cat"},
                new CatBreed { Breed = "Sphynx Cat"}
            });

            data.SaveChanges();
        }

        public static void SeedDogBreeds(PetsDatesDbContext data)
        {
            data.DogBreeds.AddRange(new[]
            {
                new DogBreed{Breed = "Labrador"},
                new DogBreed{Breed = "Bulldog"},
                new DogBreed{Breed = "German Shepherd"},
                new DogBreed{Breed = "Golden Retriever"},
                new DogBreed{Breed = "Poodle"},
                new DogBreed{Breed = "Beagle"},
                new DogBreed{Breed = "Rottweiler"},
                new DogBreed{Breed = "Dachshund"},
                new DogBreed{Breed = "Yorkshire Terrier"},
                new DogBreed{Breed = "Boxer"},
                new DogBreed{Breed = "Siberian Huskie"},
                new DogBreed{Breed = "Doberman"},
                new DogBreed{Breed = "Pomeranian"},
                new DogBreed{Breed = "Pug"},
                new DogBreed{Breed = "Cocker Spaniel"},
                new DogBreed{Breed = "Mastiff"},
                new DogBreed{Breed = "Chihuahua"},
                new DogBreed{Breed = "Basset Hound"},
                new DogBreed{Breed = "Bloodhound"},
                new DogBreed{Breed = "Dalmatian"},
                new DogBreed{Breed = "Bull Terrier"},
                new DogBreed{Breed = "Affenpinscher"},
            });

            data.SaveChanges();
        }
    }
}

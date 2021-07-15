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
            if (data.CatBreeds.Any())
            {
                return;
            }

            data.CatBreeds.AddRange(new[]
            {
                new CatBreed { Breed = "Abyssinian"},
                new CatBreed { Breed = "Balinese-Javanese"},
                new CatBreed { Breed = "Bengal"},
                new CatBreed { Breed = "Birman"},
                new CatBreed { Breed = "Bombay"},
                new CatBreed { Breed = "Burmese"},
                new CatBreed { Breed = "Chartreux"},
                new CatBreed { Breed = "Cornish Rex"},
                new CatBreed { Breed = "Devon Rex"},
                new CatBreed { Breed = "Egyptian Mau"},
                new CatBreed { Breed = "Havana Brown"},
                new CatBreed { Breed = "Himalayan"},
                new CatBreed { Breed = "Maine Coon"},
                new CatBreed { Breed = "Manx"},
                new CatBreed { Breed = "Oriental"},
                new CatBreed { Breed = "Persian"},
                new CatBreed { Breed = "Peterbald"},
                new CatBreed { Breed = "Ragdoll"},
                new CatBreed { Breed = "Scottish"},
                new CatBreed { Breed = "Siamese"},
                new CatBreed { Breed = "Siberian"},
                new CatBreed { Breed = "Sphynx"}
            });

            data.SaveChanges();
        }

        public static void SeedDogBreeds(PetsDatesDbContext data)
        {
            if (data.DogBreeds.Any())
            {
                return;
            }
            data.DogBreeds.AddRange(new[]
            {
                new DogBreed{Breed = "Affenpinscher"},
                new DogBreed{Breed = "Basset Hound"},
                new DogBreed{Breed = "Beagle"},
                new DogBreed{Breed = "Bloodhound"},
                new DogBreed{Breed = "Boxer"},
                new DogBreed{Breed = "Bull Terrier"},
                new DogBreed{Breed = "Bulldog"},
                new DogBreed{Breed = "Chihuahua"},              
                new DogBreed{Breed = "Cocker Spaniel"},
                new DogBreed{Breed = "Dachshund"},
                new DogBreed{Breed = "Dalmatian"},
                new DogBreed{Breed = "Doberman"},
                new DogBreed{Breed = "German Shepherd"},
                new DogBreed{Breed = "Golden Retriever"},
                new DogBreed{Breed = "Labrador"},
                new DogBreed{Breed = "Mastiff"},
                new DogBreed{Breed = "Pomeranian"},
                new DogBreed{Breed = "Poodle"},
                new DogBreed{Breed = "Pug"},
                new DogBreed{Breed = "Rottweiler"},
                new DogBreed{Breed = "Siberian Huskie"},
                new DogBreed{Breed = "Yorkshire Terrier"}                           
            });

            data.SaveChanges();
        }
    }
}

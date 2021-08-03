using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PetsDates.Data;
using PetsDates.Data.Models.Dogs;
using PetsDates.Data.Models.Cats;
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
                new CatBreed { Name = "Abyssinian"},
                new CatBreed { Name = "Balinese-Javanese"},
                new CatBreed { Name = "Bengal"},
                new CatBreed { Name = "Birman"},
                new CatBreed { Name = "Bombay"},
                new CatBreed { Name = "Burmese"},
                new CatBreed { Name = "Chartreux"},
                new CatBreed { Name = "Cornish Rex"},
                new CatBreed { Name = "Devon Rex"},
                new CatBreed { Name = "Egyptian Mau"},
                new CatBreed { Name = "Havana Brown"},
                new CatBreed { Name = "Himalayan"},
                new CatBreed { Name = "Maine Coon"},
                new CatBreed { Name = "Manx"},
                new CatBreed { Name = "Oriental"},
                new CatBreed { Name = "Persian"},
                new CatBreed { Name = "Peterbald"},
                new CatBreed { Name = "Ragdoll"},
                new CatBreed { Name = "Scottish"},
                new CatBreed { Name = "Siamese"},
                new CatBreed { Name = "Siberian"},
                new CatBreed { Name = "Sphynx"}
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
                new DogBreed{Name = "Affenpinscher"},
                new DogBreed{Name = "Basset Hound"},
                new DogBreed{Name = "Beagle"},
                new DogBreed{Name = "Bloodhound"},
                new DogBreed{Name = "Boxer"},
                new DogBreed{Name = "Bull Terrier"},
                new DogBreed{Name = "Bulldog"},
                new DogBreed{Name = "Chihuahua"},              
                new DogBreed{Name = "Cocker Spaniel"},
                new DogBreed{Name = "Dachshund"},
                new DogBreed{Name = "Dalmatian"},
                new DogBreed{Name = "Doberman"},
                new DogBreed{Name = "German Shepherd"},
                new DogBreed{Name = "Golden Retriever"},
                new DogBreed{Name = "Labrador"},
                new DogBreed{Name = "Mastiff"},
                new DogBreed{Name = "Pomeranian"},
                new DogBreed{Name = "Poodle"},
                new DogBreed{Name = "Pug"},
                new DogBreed{Name = "Rottweiler"},
                new DogBreed{Name = "Siberian Huskie"},
                new DogBreed{Name = "Yorkshire Terrier"}                           
            });

            data.SaveChanges();
        }
    }
}

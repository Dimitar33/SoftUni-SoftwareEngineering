using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetsDates.Data.Models;

namespace PetsDates.Data
{
    public class PetsDatesDbContext : IdentityDbContext<User>
    {  
        public PetsDatesDbContext(DbContextOptions<PetsDatesDbContext> options)
           : base(options)
        {
        }
       
        public DbSet<Cat> Cats { get; set; }
        public DbSet<CatBreed> CatBreeds { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<DogBreed> DogBreeds { get; set; }
        public DbSet<Pet> Pets { get; set; }

    }
}

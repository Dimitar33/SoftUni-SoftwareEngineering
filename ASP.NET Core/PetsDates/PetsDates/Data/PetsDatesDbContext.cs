using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetsDates.Data.Models.Dogs;
using PetsDates.Data.Models.Cats;
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Pet>()
                .HasOne(o => o.Owner)
                .WithMany(p => p.Pets)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Pet>()
                .HasOne(b => b.Breed)
                .WithMany(d => d.Pets)
                .HasForeignKey(x => x.BreedId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }

  
}

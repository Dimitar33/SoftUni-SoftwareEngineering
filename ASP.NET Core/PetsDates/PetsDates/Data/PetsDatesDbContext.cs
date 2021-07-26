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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Pet>()
                .HasOne(o => o.Owner)
                .WithMany(p => p.Pets)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Cat>()
                .HasOne(b => b.Breed)
                .WithMany(c => c.Cats)
                .HasForeignKey(x => x.CatBreedId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Dog>()
                .HasOne(b => b.Breed)
                .WithMany(d => d.Dogs)
                .HasForeignKey(x => x.DogBreedId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }

  
}

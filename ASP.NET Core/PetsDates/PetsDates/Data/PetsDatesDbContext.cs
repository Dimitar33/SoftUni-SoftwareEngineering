﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetsDates.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetsDates.Data
{
    public class PetsDatesDbContext : DbContext
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
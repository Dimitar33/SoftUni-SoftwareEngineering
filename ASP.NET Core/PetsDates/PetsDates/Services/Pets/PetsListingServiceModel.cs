﻿using PetsDates.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetsDates.Services.Pets
{
    public class PetsListingServiceModel
    {
        public int Id { get; set; }
        public string Breed { get; set; }
        public string Gender { get; set; }
        public string Name { get; set; }
        public PetPurpose Purpose { get; set; }
        public double? Price { get; set; }
        public double? Age { get; set; }
        public string Picture { get; set; }
    }
}

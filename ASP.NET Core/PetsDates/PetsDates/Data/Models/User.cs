using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System;

namespace PetsDates.Data.Models
{
    public class User : IdentityUser
    {
        public string DateRegistered { get; init; } = DateTime.UtcNow.ToString("d");
        public bool IsMod { get; set; } = false;
        public IEnumerable<Pet> Pets { get; set; } = new List<Pet>();
    }
}

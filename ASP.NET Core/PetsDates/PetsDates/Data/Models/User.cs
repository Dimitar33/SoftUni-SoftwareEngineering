using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;


namespace PetsDates.Data.Models
{
    public class User : IdentityUser
    {
        public IEnumerable<Pet> Pets { get; set; } = new List<Pet>();
    }
}

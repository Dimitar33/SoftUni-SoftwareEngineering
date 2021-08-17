using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetsDates.Areas.Administration.Models
{
    public class UserViewModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string DateRegistered { get; set; }
        public int PetsCount { get; set; }
        public bool IsMod { get; set; }
    }
}

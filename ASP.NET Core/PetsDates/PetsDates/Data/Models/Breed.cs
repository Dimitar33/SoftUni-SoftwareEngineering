using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetsDates.Data.Models
{
    public abstract class Breed
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

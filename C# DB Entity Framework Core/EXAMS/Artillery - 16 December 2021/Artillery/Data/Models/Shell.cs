﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Artillery.Data.Models
{
   public class Shell
    {
        public int Id { get; set; }

        [Range(2, 1680)]
        public double ShellWeight { get; set; }

        [Required]
        [MaxLength(30)]
        public string Caliber { get; set; }
        public ICollection<Gun> Guns { get; set; } = new List<Gun>();
    }
}

//•	Id – integer, Primary Key
//•	ShellWeight – double in range  [2…1_680] (required)
//•	Caliber – text with length [4…30] (required)
//•	Guns – a collection of Gun

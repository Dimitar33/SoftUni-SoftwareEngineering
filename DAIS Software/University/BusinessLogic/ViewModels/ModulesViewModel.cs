﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ViewModels
{
    public class ModulesViewModel
    {
        public int Id { get; set; }
        public int? CourseId { get; set; }
        public string Name { get; set; } = null!;

        public string Description { get; set; }

    }
}

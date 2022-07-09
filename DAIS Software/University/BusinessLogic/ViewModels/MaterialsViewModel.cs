using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ViewModels
{
    public class MaterialsViewModel
    {
        public int Id { get; set; }
        public int? CourseId { get; set; }
        public string Type { get; set; } = null!;
        public string Url { get; set; } = null!;

    }
}

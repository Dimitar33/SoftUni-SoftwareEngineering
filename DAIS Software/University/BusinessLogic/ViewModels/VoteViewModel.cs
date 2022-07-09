using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ViewModels
{
    public class VoteViewModel
    {
        public bool Disliked { get; set; }
        public bool Liked { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
    }
}

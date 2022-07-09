using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ViewModels
{
    public class QuestionViewModel
    {
        public int Id { get; set; }
        public int TestId { get; set; }
        public string Description { get; set; }

        public virtual List<AnswearViewModel> Answers { get; set; } = 
            Enumerable.Range(0, 4).Select(x => new AnswearViewModel()).ToList();
    }
}

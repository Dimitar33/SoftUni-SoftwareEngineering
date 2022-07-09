using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ViewModels
{
    public class AnswearViewModel
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Answear { get; set; }
        public bool IsCorrect { get; set; }

    }
}

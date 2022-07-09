using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ViewModels.ModelValidators
{
    public class DateValidation : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            DateTime date = (DateTime)value;

            if (date < DateTime.Today)
            {
                return false;
            }
            return true;
        }
    }
}

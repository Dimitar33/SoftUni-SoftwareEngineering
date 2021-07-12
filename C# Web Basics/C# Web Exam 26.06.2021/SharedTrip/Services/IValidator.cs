using SharedTrip.Models.ViewModels.TripViewModels;
using SharedTrip.Models.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Services
{
    public interface IValidator
    {
        public ICollection<string> ValidateUser(UsersRegisterViewModel model);

        public ICollection<string> ValidateTrip(TripAddViewModel model);
    }
}

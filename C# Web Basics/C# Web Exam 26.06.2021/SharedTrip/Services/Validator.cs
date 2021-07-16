﻿using SharedTrip.Models.ViewModels.TripViewModels;
using SharedTrip.Models.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SharedTrip.Services
{
    public class Validator : IValidator
    {
        public ICollection<string> ValidateUser(UsersRegisterViewModel model)
        {
            var errors = new List<string>();

            if (model.Username.Length < 5 || model.Username.Length > 20)
            {
                errors.Add($"Username '{model.Username}' is not valid. It must be between {5} and {20} characters long.");
            }

            if (!Regex.IsMatch(model.Email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
            {
                errors.Add($"Email {model.Email} is not a valid e-mail address.");
            }

            if (model.Password.Length < 6 || model.Password.Length > 20)
            {
                errors.Add($"The provided password is not valid. It must be between {6} and {20} characters long.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                errors.Add($"Password and its confirmation are different.");
            }

            return errors;
        }
        public ICollection<string> ValidateTrip(TripAddViewModel model)
        {
            var errors = new List<string>();

            if (model.Seats < 2 || model.Seats > 6)
            {
                errors.Add("Seats must be between 2 and 6");
            }

            if (model.Description.Length > 80)
            {
                errors.Add("Description can be maximum 80 simbols long");
            }

            return errors;
        }
    }
}
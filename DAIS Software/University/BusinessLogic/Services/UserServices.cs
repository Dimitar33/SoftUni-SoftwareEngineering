using BusinessLogic.Services.Interfaces;
using BusinessLogic.ViewModels;
using DataLayer.Data;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class UserServices : IUserServices
    {
        private readonly UserData data;

        public UserServices(UserData _data)
        {
            data = _data;
        }

        public bool EditUser(int id, UserViewModel model)
        {
            var user = new User
            {
                Age = model.Age,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Phone = model.Phone
            };

            return data.EditUser(id, user);

        }

        public void AddUser(UserViewModel studentModel, string role)
        {
           
            User user = new User();

            user.Age = studentModel.Age;
            user.FirstName = studentModel.FirstName;
            user.LastName = studentModel.LastName;
            user.Email = studentModel.Email;
            user.Phone = studentModel.Phone;

            this.data.AddUser(user, role);
        }

        public List<UserViewModel> GetAllUsers()
        {
            return data.GetUsers()
                .Select(x => new UserViewModel
                {
                    Id = x.UserId,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    Email = x.Email,
                    Phone = x.Phone,
                    Role = String.Join(", ", x.Roles.Select(x => x.RoleType))
                })
                .ToList();
        }

        public UserViewModel GetUser(int id)
        {
            return GetAllUsers().FirstOrDefault(x => x.Id == id);
        }
        public List<UserViewModel> GetAdmins()
        {
            return data.GetUsers()
                .Where(x => x.Roles.Any(x => x.RoleType == "Administrator"))
                .Select(x => new UserViewModel
                {
                    Id = x.UserId,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    Email = x.Email,
                    Phone = x.Phone,
                    Role = String.Join(", ", x.Roles.Select(x => x.RoleType))
                })
                .ToList();
        }

        public List<UserViewModel> GetOperators()
        {
            return data.GetUsers()
                .Where(x => x.Roles.Any(x => x.RoleType == "Operator"))
                .Select(x => new UserViewModel
                {
                    Id = x.UserId,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    Email = x.Email,
                    Phone = x.Phone,
                    Role = String.Join(", ", x.Roles.Select(x => x.RoleType))
                })
                .ToList();
        }
        public void Addrole(int id, string role)
        {
            data.AddRole(id, role);
        }

        public bool DeleteUser(int id)
        {
            return data.DeleteUser(id);
        }
    }
}

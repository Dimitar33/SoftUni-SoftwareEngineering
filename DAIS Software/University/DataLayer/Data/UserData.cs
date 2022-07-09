using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Data
{
    public class UserData
    {
        private readonly UniversityContext data;

        public UserData(UniversityContext _data)
        {
            data = _data;
        }

        
        public User GetUser(int id)
        {
            return data.Users.FirstOrDefault(x => x.UserId == id);
        }

        public List<User> GetUsers()
        {
            return data.Users.Include("Roles").ToList();
        }
        public void AddRole(int id, string roleType)
        {
            var person = data.Users.FirstOrDefault(x => x.UserId == id);
            var role = data.Roles.FirstOrDefault(x => x.RoleType == roleType);

            if (person == null || role == null)
            {
                return;
            }

            person.Roles.Add(role);
            // role.Users.Add(person); ??
            data.SaveChanges();
        }


        public void AddUser(User userMOdel, string roleString)
        {

            if (!data.Roles.Any(x => x.RoleType == roleString))
            {
                data.Roles.Add(new Role
                {
                    RoleType = roleString,
                });

                data.SaveChanges();
            }

            var role = data.Roles.FirstOrDefault(x => x.RoleType == roleString);

            if (userMOdel == null || role == null)
            {
                return;
            }

            User user = new User
            {
                FirstName = userMOdel.FirstName,
                LastName = userMOdel.LastName,
                Age = userMOdel.Age,
                Email = userMOdel.Email,
                Phone = userMOdel.Phone,
                UserType = roleString
            };

            user.Roles.Add(role);

            data.Users.Add(user);

            if (roleString == "Student")
            {
                user.Student = new Student();
            }
            else if (roleString == "Teacher")
            {
                user.Teacher = new Teacher();
            }

            data.SaveChanges();
        }

        public bool EditUser(int id, User userModel)
        {
            var user = GetUser(id);

            if (user == null)
            {
                return false;
            }

            user.FirstName = userModel.FirstName;
            user.LastName = userModel.LastName;
            user.Age = userModel.Age;
            user.Email = userModel.Email;
            user.Phone = userModel.Phone;

            data.SaveChanges();

            return true;
        }

        public bool DeleteUser(int id)
        {
            var user = GetUser(id);

            if (user == null)
            {
                return false;
            }

            data.Users.Remove(user);
            data.SaveChanges();

            return true;
        }
    }
}
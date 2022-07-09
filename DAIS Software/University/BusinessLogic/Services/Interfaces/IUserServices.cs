using BusinessLogic.ViewModels;

namespace BusinessLogic.Services.Interfaces
{
    public interface IUserServices
    {
        void Addrole(int id, string role);
        void AddUser(UserViewModel studentModel, string role);
        public bool EditUser(int id, UserViewModel model);
        public List<UserViewModel> GetAdmins();
        public List<UserViewModel> GetOperators();
        public List<UserViewModel> GetAllUsers();
        public UserViewModel GetUser(int id);
        public bool DeleteUser(int id);
    }
}
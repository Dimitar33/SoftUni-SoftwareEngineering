using BusinessLogic.ViewModels;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Interfaces
{
    public interface IStudentsServices
    {
        public string AddStudentToCourse(int studentId, int CourseId);
        public List<UserViewModel> GetStudents();
        public void RemoveStudentFromCourse(int studentId, int courseId);

        public void Vote(VoteViewModel model);
        public List<GradeViewModel> GetStudentGrades(int studentId);
        public UserViewModel GetStudent(int id);
    }
}

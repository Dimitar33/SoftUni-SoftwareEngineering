using BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Interfaces
{
    public interface ITeachersServices
    {
        public string AddTeacherToCourse(int teacherId, int courseId);

        public int TeachersCourse(int id);
        public List<UserViewModel> GetTeachers();
        public UserViewModel GetTeacher(int id);

        public void CreateTest(int id, TestViewModel model);
        public bool DeleteTest(int id);
        public List<TestViewModel> GetTests(int id);
        public List<TestViewModel> GetTestsForCourse(int id);
        public List<QuestionViewModel> GetQuestions(int id);
        public void CreateQuestion(int id, string description);
        public void AddQuestion(QuestionViewModel model);


    }
}

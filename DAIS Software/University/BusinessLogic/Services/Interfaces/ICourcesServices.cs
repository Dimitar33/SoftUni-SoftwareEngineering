using BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Interfaces
{
    public interface ICourcesServices
    {
        public CourseViewModel GetCourse(int id);
        public List<CourseViewModel> GetCources();
        public TestViewModel GetTest(int id);
        public bool DeleteMatetial(int id);
        public List<MaterialsViewModel> GetMaterialsForCourse(int id);
        public void AddMaterials(int id, MaterialsViewModel model);
        public string AddGrade(GradeViewModel model);
        public List<ModulesViewModel> GetModules(int id);
        public void AddModule(int id, ModulesViewModel model);
        public void CreateCourse(CourseViewModel model, int teacherId);
        public List<UserViewModel> GetStudentsFromCourse(int courseId);
        public bool EditCourse(int id, CourseViewModel model);

        public bool DeleteCourse(int id);
    }
}

using BusinessLogic.Services.Interfaces;
using BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace University.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourcesServices courceServices;
        private readonly IStudentsServices studentServices;

        public CoursesController(ICourcesServices cs, IStudentsServices ss)
        {
            this.courceServices = cs;
            this.studentServices = ss;
        }

        public IActionResult Materials(int id)
        {
            var mats = courceServices.GetMaterialsForCourse(id);

            return View(mats);
        }
        public IActionResult AddMaterial()
        {
            return View(new MaterialsViewModel());
        }

        [HttpPost]
        public IActionResult AddMaterial(int id, MaterialsViewModel model)
        {
            courceServices.AddMaterials(id, model);
            var mats = courceServices.GetMaterialsForCourse(id);


            return View("Materials", mats);
        }

        public IActionResult Modules(int id)
        {
            var modules = courceServices.GetModules(id);

            return View(modules);
        }

        public IActionResult AddModule(int id)
        {
            return View(new ModulesViewModel());
        }

        [HttpPost]
        public IActionResult AddModule(int id, ModulesViewModel model)
        {
            courceServices.AddModule(id, model);

            var modules = courceServices.GetModules(id);

            return View("Modules", modules);
        }

        public IActionResult TestDetails(int id)
        {
            var test = courceServices.GetTest(id);

            return View(test);
        }

        public IActionResult CourseStudents(int id)
        {
            var students = courceServices.GetStudentsFromCourse(id);
            ViewBag.courseId = id;

            return View(students);
        }
        public string DeleteMaterial(int id)
        {
            return courceServices.DeleteMatetial(id) == true
                ? "Material deleted"
                : "Cant delete material";
        }
        public IActionResult Details(int id)
        {
            var course = courceServices.GetCourse(id);

            return View(course);
        }

        public IActionResult WriteGrade(int studentId, int courseId)
        {
            var student = studentServices.GetStudent(studentId);

            var grade = new GradeViewModel
            {
                CoureseId = courseId,
                SudentId = studentId,
                StudentsNames = student.FirstName + " " + student.LastName,
            };

            return View(grade);
        }

        [HttpPost]
        public IActionResult WriteGrade(int studentId, int courseId, GradeViewModel model)
        {
            var student = studentServices.GetStudent(studentId);

            model.StudentsNames = student.FirstName + " " + student.LastName;
            model.CoureseId = courseId;
            model.SudentId = studentId;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ViewBag.Message = courceServices.AddGrade(model);
            ViewBag.courseId = courseId;

            var students = courceServices.GetStudentsFromCourse(courseId);

            return View("CourseStudents", students);
        }

        public IActionResult CreateCourse(int id)
        {
            return View(new CourseViewModel());
        }

        [HttpPost]
        public IActionResult CreateCourse(int id, CourseViewModel course)
        {
            courceServices.CreateCourse(course, id);

            var courses = courceServices.GetCources();

            return View("Courses", courses);
        }


        public IActionResult Edit(int id)
        {
            var course = courceServices.GetCourse(id);

            return View(course);
        }

        [HttpPost]
        public IActionResult Edit(int id, CourseViewModel model)
        {
            courceServices.EditCourse(id, model);

            return RedirectToAction("Courses");
        }
        public IActionResult Courses()
        {
            var cources = courceServices.GetCources();

            return View(cources);
        }

        public IActionResult Delete(int id)
        {
            courceServices.DeleteCourse(id);

            return RedirectToAction("Courses");
        }
    }
}

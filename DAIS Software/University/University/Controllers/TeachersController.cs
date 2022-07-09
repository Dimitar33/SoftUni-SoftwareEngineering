using BusinessLogic.Services.Interfaces;
using BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace University.Controllers
{
    public class TeachersController : Controller
    {
         private readonly IUserServices userServices;
         private readonly ITeachersServices teacherServices;
         private readonly ICourcesServices courseServices;

        public TeachersController(IUserServices us, ITeachersServices ts, ICourcesServices cs)
        {
            userServices = us;
            teacherServices = ts;
            courseServices = cs;
        }

        public IActionResult Details(int id)
        {
            var teacher = teacherServices.GetTeacher(id);

            return View(teacher);
        }

        public IActionResult Edit(int id)
        {
            var student = teacherServices.GetTeacher(id);

            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(int id, UserViewModel model)
        {

            userServices.EditUser(id, model);

            return RedirectToAction("Teachers", "Teachers");
        }

        public IActionResult TestDetails()
        {
            return View();
        }

        public IActionResult Courses(int id)
        {
            var teacher = teacherServices.GetTeacher(id);
            var courses = teacher.Courses;
            ViewBag.teacherId = id;

            return View(courses);
        }
        public IActionResult AddQuestion()
        {
           
            return View(new QuestionViewModel());
        }

        [HttpPost]
        public IActionResult AddQuestion(int id, QuestionViewModel model)
        {
            model.TestId = id;

            teacherServices.AddQuestion(model);

            var test = courseServices.GetTest(id);

            return RedirectToAction("TestDetails", "Courses", test);
        }

        public IActionResult AddAnswer(int id)
        {
            return View(new AnswearViewModel());
        }

        [HttpPost]
        public IActionResult AddAnswer(int id, AnswearViewModel model)
        {

            return View();
        }


        public void DeleteTest(int id)
        {
            teacherServices.DeleteTest(id);

        }
        
        public IActionResult Questions(int id)
        {
           var questions = teacherServices.GetQuestions(id);

            return View(questions);
        }

        public IActionResult Tests(int id)
        {
            var test = teacherServices.GetTests(id);

            return View(test);
        }

        public IActionResult CreateTest(int id)
        {
            return View(new TestViewModel());
        }

        [HttpPost]
        public IActionResult CreateTest(int id, TestViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            teacherServices.CreateTest(id,model);
            var tests = teacherServices.GetTestsForCourse(id);

            ViewBag.teacherId = id;


            return View("Tests", tests);
        }
        public IActionResult Teachers()
        {
            var teachers = teacherServices.GetTeachers();

            return View(teachers);
        }

        public IActionResult AsignTeacherToCourse(int studentId, int courseId)
        {
            ViewBag.result = teacherServices.AddTeacherToCourse(studentId, courseId);

            return View("ResultView");

        }
        public IActionResult AddTeacherToCourse(int teacherId, int courseId)
        {

            teacherServices.AddTeacherToCourse(teacherId = 2, courseId = 1);
            ViewBag.asd = teacherServices.TeachersCourse(teacherId);

            return View();
        }
        public IActionResult CreateTeacher()
        {
            return View(new UserViewModel());
        }

        [HttpPost]
        public IActionResult CreateTeacher(UserViewModel teacherModel)
        {

            userServices.AddUser(teacherModel, "Teacher");
            var teachers = teacherServices.GetTeachers();

            return View("Teachers", teachers);
        }

        public IActionResult Delete(int id)
        {
            userServices.DeleteUser(id);

            return RedirectToAction("Teachers");
        }
    }
}

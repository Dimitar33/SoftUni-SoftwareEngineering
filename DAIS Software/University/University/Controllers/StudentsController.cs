using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.ViewModels;
using BusinessLogic.Services.Interfaces;

namespace University.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentsServices studentServices;
        private readonly IUserServices userServices;
        private readonly ICourcesServices courseServices;

        public StudentsController(IStudentsServices _studentServices, IUserServices _userServices, ICourcesServices _courseServices)
        {
            this.studentServices = _studentServices;
            this.userServices = _userServices;
            this.courseServices = _courseServices;
        }

        public IActionResult Edit(int id)
        {
            var student = studentServices.GetStudent(id);

            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(int id, UserViewModel model)
        {

            userServices.EditUser(id, model);

            return RedirectToAction("Students", "Students");
        }
        public IActionResult Details(int id)
        {
            var student = this.studentServices.GetStudent(id);

            return View(student);
        }

        public void Like(int studentId, int courseId)
        {
            var vote = new VoteViewModel
            {
                CourseId = courseId,
                StudentId = studentId,
                Disliked = false,
                Liked = true
            };

            studentServices.Vote(vote);
        }

        public void Dislike(int studentId, int courseId)
        {
            var vote = new VoteViewModel
            {
                CourseId = courseId,
                StudentId = studentId,
                Disliked = true,
                Liked = false
            };

            studentServices.Vote(vote);
        }
        public IActionResult StudentGrades(int id)
        {
            var grades = studentServices.GetStudentGrades(id);

            return View(grades);
        }
       
        public IActionResult StudentCourses(int id)
        {

            var student = studentServices.GetStudent(id);
            var courses = student.Courses;
            ViewBag.StudentId = id;

            return View(courses);
        }
        public IActionResult ChoseCourse(int id)
        {
            var courses = courseServices.GetCources();

            ViewBag.studentId = id;

            return View(courses);
        }

        public IActionResult AsignStudentToCourse(int studentId, int courseId)
        {
            ViewBag.Message = studentServices.AddStudentToCourse(studentId, courseId);
            ViewBag.studentId = studentId;
            var student = this.studentServices.GetStudent(studentId);
            var courses = student.Courses;

            return View("StudentCourses", courses);

        }

        public IActionResult RemoveStudentFromCourse(int studentId, int courseId)
        {
            studentServices.RemoveStudentFromCourse(studentId, courseId);
            var student = this.studentServices.GetStudent(studentId);
            var courses = student.Courses;

            ViewBag.studentId = studentId;

            return View("StudentCourses", courses);
        }

        public IActionResult CreateStudent()
        {
            return View(new UserViewModel());
        }

        [HttpPost]
        public IActionResult CreateStudent(UserViewModel studentModel)
        {
            if (!ModelState.IsValid)
            {
                return View(studentModel);
            }

            userServices.AddUser(studentModel, "Student");
            var students = studentServices.GetStudents();

            return View("Students", students);
        }


        public IActionResult Students()
        {
            var result = studentServices.GetStudents();

            return View(result);
        }

        public IActionResult Delete(int id)
        {
            userServices.DeleteUser(id);

            return RedirectToAction("Students");
        }
    }
}

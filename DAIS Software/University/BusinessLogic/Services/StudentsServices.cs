using BusinessLogic.Services.Interfaces;
using BusinessLogic.ViewModels;
using DataLayer.Data;
using DataLayer.Data;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class StudentsServices : IStudentsServices
    {
        private readonly StudentsData studentData;
        private readonly CoursesData courseData;

        public StudentsServices(StudentsData sd, CoursesData cd)
        {
            this.studentData = sd;
            this.courseData = cd;
        }

        public List<GradeViewModel> GetStudentGrades(int studentId)
        {
            
            var grades = studentData.GetGrades()
                .Where(x => x.StudentId == studentId)
                .Select(x => new GradeViewModel
                {
                    Course = x.Course.Name,
                    Score = x.Score1,
                    CoureseId = x.CourseId

                }).ToList();

            return grades;
        }

        public void Vote(VoteViewModel model)
        {
            var vote = new CourseVote
            {
                Liked = model.Liked,
                Disliked = model.Disliked,
                CourseId = model.CourseId,
                StudentId = model.StudentId
            };

            studentData.Vote(vote);

        }

        public void RemoveStudentFromCourse(int studentId, int courseId)
        {
            this.studentData.RemoveStudentFromCourse(studentId, courseId);
        }
        public string AddStudentToCourse(int studentId, int CourseId)
        {
            var user = studentData.GetStudent(studentId);
            var course  = courseData.GetCourse(CourseId);

            try
            {
                if (user == null || course == null)
                {
                    throw new Exception(message:"No such student or course");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            if (user.Student.Courses.Contains(course))
            {
                return "The student is awready in this course";
            }

            if (course.Students.Count >= 100)
            {
                return "Course limit of 100 participants reached";
            }

            if (user.Student.Courses.Count >= 10)
            {
                return "Maximum course count reached";
            }

            int courseDificultiCount = user.Student.Courses.Where(x => x.Dificulty >= 4).Count();

            if (courseDificultiCount == 5)
            {
                return "Cant have more than 5 courses with dificulti higher than 4";
            }

            this.studentData.AddStudentToCourse(studentId, CourseId);

            return "Student successfully added to course";
        }

        public UserViewModel GetStudent(int id)
        {
            var user = studentData.GetStudent(id);

            return new UserViewModel
            {
                Age = user.Age,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Id = id,
                Phone = user.Phone,
                Role = string.Join(" ", user.Roles.Select(x => x.RoleType)),
                Courses = user.Student.Courses.Select(x => new CourseViewModel
                {
                    Name = x.Name,
                    StudentsCount = x.StudentsCount,
                    Descriotion = x.Descriotion,
                    Dificulty = x.Dificulty,
                    Id = x.Id,
                    TeacherName = 
                    x.Teacher == null 
                    ? "To be determined" 
                    : (x.Teacher.User.FirstName + " " + x.Teacher.User.FirstName),

                    
                }).ToList(),
            };
        }
        public List<UserViewModel> GetStudents()
        {
            return studentData.GetStudents().Select(x => new UserViewModel
            {
                Id = x.UserId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Age = x.Age,
                Email = x.Email,
                Phone = x.Phone,
                Role = string.Join(" ", x.Roles.Select(x => x.RoleType)),
                Courses = x.Student.Courses.Select(x => new CourseViewModel
                {
                    Name = x.Name,
                    StudentsCount = x.StudentsCount,
                    Descriotion = x.Descriotion,
                    Dificulty = x.Dificulty,
                    Id = x.Id,
                    TeacherName =
                    x.Teacher == null
                    ? "To be determined"
                    : (x.Teacher.User.FirstName + " " + x.Teacher.User.FirstName),

                }).ToList(),

            }).ToList();
        }

    }
}

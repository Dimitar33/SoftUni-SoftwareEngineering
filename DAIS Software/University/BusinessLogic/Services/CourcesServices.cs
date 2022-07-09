using BusinessLogic.Services.Interfaces;
using BusinessLogic.ViewModels;
using DataLayer.Data;
using DataLayer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class CourcesServices : ICourcesServices
    {
        private readonly CoursesData data;

        public CourcesServices(CoursesData _data)
        {
            this.data = _data;
        }

        public List<MaterialsViewModel> GetMaterialsForCourse(int id)
        {
            return data.GetMaterials(id).Select(x => new MaterialsViewModel
            {
                Id = x.Id,
                Type = x.Type,
                Url = x.Url,

            }).ToList();
        }

        public void AddMaterials(int id, MaterialsViewModel model)
        {
            var material = new CourseMaterial
            {
                CourseId = id,
                Type = model.Type,
                Url = model.Url,
            };

            data.AddMaterials(id, material);
        }

        public void AddModule(int id, ModulesViewModel model)
        {
            var module = new CourseModule
            {
                Id = model.Id,
                CourseId = id,
                Name = model.Name,
                Description = model.Description,
            };

            data.AddModule(module);
        }

        public List<ModulesViewModel> GetModules(int id)
        {
           return data.GetModules(id).Select(x => new ModulesViewModel
           {
               Id = x.Id,
               CourseId = x.CourseId,
               Name = x.Name,
               Description = x.Description,

           }).ToList();
        }
        public TestViewModel GetTest(int id)
        {
            var test = data.GetTest(id);

            return new TestViewModel
            {
                Id = id,
                Duration = test.Duration,
                EndDate = test.EndDate,
                StartDate = test.StartDate,
                Questions = test.Questions.Select(x => new QuestionViewModel
                {
                    Description = x.Description,
                    Id = x.Id,

                    Answers = x.Answers.Select(x => new AnswearViewModel
                    {
                        Answear = x.Answear,
                        Id = x.Id,
                        IsCorrect = x.IsCorrect,


                    }).ToList()

                }).ToList()
            };
        }

        public bool DeleteMatetial(int id)
        {
            return data.DeleteMaterial(id) == 0 ? false : true;

        }
        public void CreateCourse(CourseViewModel model, int teacherId)
        {
            var course = new Course
            {
                Name = model.Name,
                Descriotion = model.Descriotion,
                Dificulty = model.Dificulty,
                TeacherId = teacherId,
            };

            data.CreateCourse(course);
        }

        public bool EditCourse(int id, CourseViewModel model)
        {
            var course = new Course
            {
                Name = model.Name,
                Dificulty = model.Dificulty,
                Descriotion = model.Descriotion
            };

            return data.EditCourse(id, course);

        }

        public List<CourseViewModel> GetCources()
        {
            return data.GetCources().Select(x => new CourseViewModel
            {
                Id = x.Id,
                Name = x.Name,
                StudentsCount = x.StudentsCount,
                CourseModules = String.Join(", ", x.CourseModules.Select(c => c.Name)),
                Descriotion = x.Descriotion,
                Dificulty = x.Dificulty,
                Likes = x.Likes,
                TeacherId = x.TeacherId

            }).ToList();
        }

        public List<UserViewModel> GetStudentsFromCourse(int courseId)
        {
            return data.GetStudentsFromCourse(courseId).Select(x => new UserViewModel
            {
                Age = x.Age,
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Id = x.UserId,
                Phone = x.Phone,
                Role = string.Join(" ", x.Roles.Select(x => x.RoleType))


            }).ToList();
        }

        public CourseViewModel GetCourse(int id)
        {
            var course = data.GetCourse(id);

            return new CourseViewModel
            {
                Id = course.Id,
                StudentsCount = course.StudentsCount,
                Name = course.Name,
                Descriotion = course.Descriotion,
                TeacherId = course.TeacherId,
                Likes = course.Likes,

                TeacherName = course.Teacher == null
                ? "N/A"
                : course.Teacher.User.FirstName + course.Teacher.User.LastName,

                Dificulty = course.Dificulty,
                CourseModules = String.Join(", ", course.CourseModules.Select(x => x.Name))
            };
        }

        public string AddGrade(GradeViewModel model)
        {
            var score = data.GetScores()
                .FirstOrDefault(x => 
                x.CourseId == model.CoureseId && 
                x.StudentId == model.SudentId);

            if (score != null)
            {
                return "Student already have grade for this course";
            }

            var grade = new Score
            {
                CourseId = model.CoureseId,
                StudentId = model.SudentId,
                Score1 = model.Score
            };

            data.CreateScore(grade);

            return "Grade added";
        }

        public bool DeleteCourse(int id)
        {
            return data.DeleteCourse(id);
        }
    }
}

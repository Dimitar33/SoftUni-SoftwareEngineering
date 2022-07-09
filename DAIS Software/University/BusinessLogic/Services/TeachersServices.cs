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
    public class TeachersServices : ITeachersServices
    {
        private readonly TeachersData data;
        public TeachersServices(TeachersData _data)
        {
            data = _data;
        }


        public void AddQuestion(QuestionViewModel model)
        {
            var question = new Question
            {
                Description = model.Description,
                TestId = model.TestId,
                Answers = model.Answers.Select(x => new Answer
                {
                    Answear = x.Answear,
                    IsCorrect = x.IsCorrect,

                }).ToList()
            };

            data.AddQuestion(question);

            var questionId = data.GetQuestions(model.TestId).Last().Id;

            question.Answers.Select(x => x.QuestionId = questionId).ToList();

            foreach (var answer in question.Answers)
            {
                data.AddAnswer(answer);
            }
        }

        public List<QuestionViewModel> GetQuestions(int id)
        {
            return data.GetQuestions(id).Select(x => new QuestionViewModel
            {
                Description = x.Description
            }).ToList();

        }


        public List<TestViewModel> GetTests(int id)
        {
            return data.GetTests(id).Select(x => new TestViewModel
            {
                Id = x.Id,
                EndDate = x.EndDate,
                Duration = x.Duration,
                StartDate = x.StartDate,

            }).ToList();
        }

        public List<TestViewModel> GetTestsForCourse(int id)
        {
            return data.GetTests(id).Select(x => new TestViewModel
            {
                Id = x.Id,
                Duration = x.Duration,
                EndDate = x.EndDate,
                StartDate = x.StartDate,


            }).ToList();

        }
        public void CreateTest(int id, TestViewModel model)
        {
            var test = new Test
            {
                CourseId = model.CourseId,
                Duration = model.Duration,
                EndDate = model.EndDate,
                StartDate = model.StartDate,
            };

            data.CreateTest(id, test);
        }

        public bool DeleteTest(int id)
        {
            return data.DeleteTest(id);
        }
        public void CreateQuestion(int id, string description)
        {
            data.CreateQuestion(id, description);
        }
        public UserViewModel GetTeacher(int id)
        {
            var user = data.GetTeacher(id);

            return new UserViewModel
            {
                Age = user.Age,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Id = id,
                Phone = user.Phone,
                Courses = user.Teacher.Courses.Select(x => new CourseViewModel
                {
                    Name = x.Name,
                    StudentsCount = x.StudentsCount,
                    Descriotion = x.Descriotion,
                    Dificulty = x.Dificulty,
                    Id = x.Id,
                    TeacherName = x.Teacher.User.FirstName + " " + x.Teacher.User.FirstName,

                }).ToList(),
            };
        }
        public string AddTeacherToCourse(int teacherId, int courseId)
        {
            data.AddTeacherToCourse(teacherId, courseId);

            return "Teacher added to course";
        }

        public int TeachersCourse(int id)
        {
            return data.TeachersCourse(id);
        }

        
        public List<UserViewModel> GetTeachers()
        {
            return data.GetTeachers().Select(x => new UserViewModel
            {
                Id = x.UserId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Age = x.Age,
                Email = x.Email,
                Phone = x.Phone,
                Courses = x.Teacher.Courses.Select(x => new CourseViewModel
                {
                    Name = x.Name,
                    StudentsCount = x.StudentsCount,
                    Descriotion = x.Descriotion,
                    Dificulty = x.Dificulty,
                    Id = x.Id,
                    TeacherName = x.Teacher.User.FirstName + " " + x.Teacher.User.FirstName,

                }).ToList(),
                Role = string.Join(" ", x.Roles.Select(x => x.RoleType))

            }).ToList();
        }
    }
}

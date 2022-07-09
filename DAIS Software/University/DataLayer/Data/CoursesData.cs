using DataLayer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Data
{
    public class CoursesData
    {
        private readonly UniversityContext data;
        private readonly IConfiguration config;
        public CoursesData(UniversityContext _data, IConfiguration _config)
        {
            this.data = _data;
            this.config = _config;
        }
        public string Config => config.GetConnectionString("DefaultConnection");

        public IQueryable<User> GetStudentsFromCourse(int courseId)
        {
            return data.Users
                .Include(x => x.Student)
                .Include("Roles")
                .Where(x => x.Student.Courses.Any(x => x.Id == courseId));
        }
        public List<Course> GetCources()
        {
            return data.Courses.Include("CourseModules").ToList();
        }

        public Course GetCourse(int id)
        {
            return data.Courses
                .Include("CourseModules")
                .Include("Students")
                .Include(x => x.Teacher)
                .ThenInclude(x => x.User)
                .FirstOrDefault(x => x.Id == id);

        }

        public List<CourseMaterial> GetMaterials(int id)
        {
            string query = @"SELECT * FROM CourseMaterials
                                WHERE CourseId = @id";

            List<CourseMaterial> mats = new List<CourseMaterial>();

            using (SqlConnection con = new SqlConnection(Config))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CourseMaterial courseMaterial = new CourseMaterial();

                        courseMaterial.Id = (int)reader["Id"];
                        courseMaterial.Url = (string)reader["Url"];
                        courseMaterial.Type = (string)reader["Type"];

                        mats.Add(courseMaterial);
                    }
                }
            }
            return mats;
        }
        public void AddMaterials(int id, CourseMaterial model)
        {
            string query = @" INSERT INTO CourseMaterials (CourseId, Type, Url) VALUES
	                                      (@courseId, @type, @url)";

            using (SqlConnection con = new SqlConnection(Config))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@courseId", id);
                cmd.Parameters.AddWithValue("@type", model.Type);
                cmd.Parameters.AddWithValue("@url", model.Url);

                cmd.ExecuteNonQuery();
            }
        }

        public int DeleteMaterial(int id)
        {
            string query = @"DELETE CourseMaterials
                                WHERE Id = @id";

            using (SqlConnection con = new SqlConnection(Config))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);

                return cmd.ExecuteNonQuery();
            }

        }

        public void AddModule(CourseModule model)
        {
            string query = @"INSERT INTO CourseModules (CourseId, Name, Description) VALUES
	                            (@courseId, @name, @description)";

            using(SqlConnection con = new SqlConnection(Config))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@courseId", model.CourseId);
                cmd.Parameters.AddWithValue("@name", model.Name);
                cmd.Parameters.AddWithValue("@description", model.Description);

                cmd.ExecuteNonQuery();

            }
        }

        public List<CourseModule> GetModules(int id)
        {
            string query = @"SELECT * FROM CourseModules
                                WHERE CourseId = @id";

            List<CourseModule> modules = new List<CourseModule>();

            using (SqlConnection con = new SqlConnection(Config))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue(@"id", id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CourseModule module = new CourseModule
                        {
                            Id = (int)reader["Id"],
                            CourseId = (int)reader["CourseId"],
                            Name = (string)reader["Name"],
                            Description = (string)reader["Description"],
                        };

                        modules.Add(module);
                    }
                }
            }
            return modules;
        }

        public Test GetTest(int id)
        {
            var test = data.Tests
                .Include(x => x.Questions)
                .ThenInclude(x => x.Answers)
                .FirstOrDefault(x => x.Id == id);

            if (test == null)
            {
                return null;
            }

            return new Test
            {
                Id = id,
                Duration = test.Duration,
                EndDate = test.EndDate,
                StartDate = test.StartDate,
                Questions = test.Questions.Select(x => new Question
                {
                    Id = x.Id,
                    Description = x.Description,
                    Answers = x.Answers.Select(x => new Answer
                    {
                        Id = x.Id,
                        Answear = x.Answear,
                        IsCorrect = x.IsCorrect,
                        
                    }).ToList()
                }).ToList()
            };


            //string query = @"SELECT * FROM Tests t
            //                 JOIN Questions q ON q.TestId = t.Id
            //                 JOIN Answers a ON a.QuestionId = q.Id
            //                 WHERE t.Id = @id";

            //using (SqlConnection con = new SqlConnection(Config))
            //{
            //    con.Open();

            //    SqlCommand cmd = new SqlCommand(query, con);
            //    cmd.Parameters.AddWithValue("@id", id);

            //    using (SqlDataReader reader = cmd.ExecuteReader())
            //    {
            //        while (reader.Read())
            //        {
            //            SqlDataReader questionReader = reader.getdat
            //            Test test = new Test
            //            {
            //                Id = (int)reader["Id"],
            //                Duration = (int)reader["Duration"],
            //                StartDate = (DateTime)reader["StartDate"],
            //                EndDate = (DateTime)reader["EndDate"],
            //                Questions =
            //            }
            //        }
            //    }

            //}
        }

        public void CreateCourseMaterials(CourseMaterial model)
        {
            var material = new CourseMaterial
            {
                Type = model.Type,
                Url = model.Url,
            };

            data.CourseMaterials.Add(material);
            data.SaveChanges();
        }

        public void CreateQuestion(Question model)
        {
            var question = new Question
            {
                Description = model.Description,
            };

            data.Questions.Add(question);
            data.SaveChanges();
        }

        public void CreateAnswer(Answer model)
        {
            var answer = new Answer
            {
                Answear = model.Answear,
                IsCorrect = model.IsCorrect,
            };

            data.Answers.Add(answer);
            data.SaveChanges();
        }
        public void CreateTest(Test model)
        {
            var test = new Test
            {
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Duration = model.Duration
            };

            data.Tests.Add(test);
            data.SaveChanges();
        }

        public IQueryable<Score> GetScores()
        {
            return data.Scores;
        }
        public void CreateScore(Score model)
        {
            var score = new Score
            {
                CourseId = model.CourseId,
                StudentId = model.StudentId,
                Score1 = model.Score1,
            };

            data.Scores.Add(score);
            data.SaveChanges();
        }

        public void CreateCourse(Course model)
        {
            var course = new Course
            {
                Name = model.Name,
                StudentsCount = 0,
                Descriotion = model.Descriotion,
                Dificulty = model.Dificulty,
                TeacherId = model.TeacherId,
            };

            data.Courses.Add(course);
            data.SaveChanges();
        }

        public bool EditCourse(int id, Course model)
        {
            var course = data.Courses.FirstOrDefault(x => x.Id == id);

            if (course == null)
            {
                return false;
            }

            course.Name = model.Name;
            course.Descriotion = model.Descriotion;
            course.Dificulty = model.Dificulty;

            data.SaveChanges();
            return true;
        }

        public bool DeleteCourse(int id)
        {
            var course = data.Courses.FirstOrDefault(x => x.Id == id);

            if (course == null)
            {
                return false;
            }

            data.Courses.Remove(course);
            data.SaveChanges();

            return true;
        }
    }
}

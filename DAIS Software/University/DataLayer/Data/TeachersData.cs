using DataLayer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Data
{
    public class TeachersData
    {
        private readonly UniversityContext data;
        private string conString = "";


        public TeachersData(UniversityContext _data, IConfiguration config)
        {
            data = _data;
            conString = config.GetConnectionString("DefaultConnection");
        }

        public void AddQuestion(Question model)
        {
            string query = @"INSERT INTO Questions(TestId, Description) VALUES
                                                    (@testId, @description)";

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@testId", model.TestId);
                cmd.Parameters.AddWithValue("@description", model.Description);

                cmd.ExecuteNonQuery();

            }
        }

        public void AddAnswer(Answer model)
        {
            string query = @"INSERT INTO Answers(QuestionId, Answear, IsCorrect) VALUES
	                                            (@questionId, @answear, @isCorrect)";

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@questionId", model.QuestionId);
                cmd.Parameters.AddWithValue("@answear", model.Answear);
                cmd.Parameters.AddWithValue("@isCorrect", model.IsCorrect);

                cmd.ExecuteNonQuery();
            }
        }
        public List<User> GetTeachers()
        {
            return data.Users
                .Include("Teacher")
                .Include("Roles")
                .Include(x => x.Teacher.Courses)
                .Where(x => x.Roles.All(x => x.RoleType == "Teacher"))
                .ToList();
        }

        public User GetTeacher(int id)
        {
            return data.Users
                .Include("Teacher")
                .Include("Roles")
                .Include(x => x.Teacher.Courses)
                .FirstOrDefault(x => x.UserId == id);
        }
        public int TeachersCourse(int id)
        {
            var teacher = data.Teachers.FirstOrDefault(x => x.UserId == 26);

            return teacher.Courses.Count();
        }

        public List<Question> GetQuestions(int id)
        {
            string query = @"SELECT * FROM Questions q
                                JOIN Tests t ON t.Id = q.TestId
                                WHERE t.Id = @id";

            List<Question> questions = new List<Question>();

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var question = new Question
                        {
                            Id = reader.GetInt32("id"),
                            Description = reader.GetString("description")
                        };

                        questions.Add(question);
                    }
                }
            }
            return questions;
        }

        public List<Test> GetTests(int id)
        {
            string query = @"SELECT * FROM Tests t
                                JOIN Course c ON c.Id = t.CourseId
                                WHERE c.Id = '" + id + "'";

            List<Test> tests = new List<Test>();

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(query, con);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var test = new Test
                        {
                            Id = (int)reader["Id"],
                            Duration = (int)reader["Duration"],
                            EndDate = (DateTime)reader["EndDate"],
                            StartDate = (DateTime)reader["StartDate"],

                        };

                        tests.Add(test);
                    }
                }
            }
            return tests;
        }

        public bool DeleteTest(int id)
        {
            string query = @"DELETE Tests
                        WHERE Id = @id";

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);

                return cmd.ExecuteNonQuery() == 0 ? false : true;
            }
        }
        public int CreateQuestion(int testId, string description)
        {
            string query = @"INSERT INTO Questions(TestId, Description) VALUES (@tesId, @desctiption)";


            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@testId", testId);
                cmd.Parameters.AddWithValue("@description", description);
                return cmd.ExecuteNonQuery();
            }
        }


        public void CreateTest(int id, Test model)
        {

            string query = @"INSERT INTO Tests(CourseId, Duration, StartDate, EndDate) VALUES
	                            (@courseId, @duration, @startDate, @endDate)";

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@courseId", id);
                cmd.Parameters.AddWithValue("@duration", model.Duration);
                cmd.Parameters.AddWithValue("@startDate", model.StartDate);
                cmd.Parameters.AddWithValue("@endDate", model.EndDate);

                cmd.ExecuteNonQuery();
            }
        }
        public void AddTeacherToCourse(int teacherId, int courseId)
        {
            var teacher = data.Teachers.FirstOrDefault(x => x.UserId == teacherId);

            var asd = data.Teachers.FirstOrDefault(x => x.Courses.Any(x => x.Id == 2));

            var course = data.Courses.FirstOrDefault(x => x.Id == courseId);

            if (teacher == null || course == null)
            {
                return;
            }

            teacher.Courses.Add(course);
            data.SaveChanges();
        }
    }
}

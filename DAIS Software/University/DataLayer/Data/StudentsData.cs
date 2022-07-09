using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Data
{
    public class StudentsData
    {

        private readonly UniversityContext data;
        public StudentsData(UniversityContext _data)
        {
            this.data = _data;
        }


        public void RemoveStudentFromCourse(int studentId, int courseId)
        {
            var student = GetStudent(studentId);
            var course = data.Courses.FirstOrDefault(x => x.Id == courseId);

            if (student == null || course == null)
            {
                return;
            }

            student.Student.Courses.Remove(course);
            course.StudentsCount--;

            data.SaveChanges();
        }
        public void AddStudentToCourse(int studentId, int courseId)
        {
            var student = data.Students.FirstOrDefault(x => x.UserId == studentId);
            var course = data.Courses.FirstOrDefault(x => x.Id == courseId);

            student.Courses.Add(course);

            course.StudentsCount++;

            data.SaveChanges();
        }

        public void Vote(CourseVote model)
        {
            var course = data.Courses.FirstOrDefault(x => x.Id == model.CourseId);
            var vote = data.CourseVotes.FirstOrDefault(x =>
            x.CourseId == model.CourseId &&
            x.StudentId == model.StudentId);

            if (course == null)
            {
                return;
            }

            if (vote == null)
            {
                vote = new CourseVote
                {
                    CourseId = model.CourseId,
                    StudentId = model.StudentId,
                    Disliked = model.Disliked,
                    Liked = model.Liked,
                };

                data.CourseVotes.Add(vote);
            }

            if (vote.Liked == true)
            {
                vote.Course.Likes++;

                vote.Liked = false;
                vote.Disliked = true;
            }
            else
            {
                vote.Course.Likes--;

                vote.Liked = true;
                vote.Disliked = false;
            }

            data.SaveChanges();
        }

        public IQueryable<Score> GetGrades()
        {
            return data.Scores
                .Include(x => x.Course)
                .Include(x => x.Student);
        }

        public User GetStudent(int id)
        {
            return data.Users
                .Include("Student")
                .Include("Roles")
                .Include(x => x.Student.Courses)
                .FirstOrDefault(x => x.UserId == id);
        }
        public List<User> GetStudents()
        {
            return data.Users
                .Include("Student")
                .Include("Roles")
                .Where(x => x.Roles.All(x => x.RoleType == "Student"))
                .ToList();
        }
    }
}

using Task_1._Code_first._Console_app.Data;
using Task_1._Code_first._Console_app.Data.Models;

namespace Task_1._Code_first._Console_app
{
    internal class Program
    {

        static void Main(string[] args)
        {
            SchoolDbContext context = new SchoolDbContext();

            context.Database.EnsureDeleted();
            if (!context.Database.EnsureCreated())
            {
                context.Database.EnsureCreated();
            }

            context.Teachers.AddRange(new[]
            {
                new Teacher{FirstName = "Scarlet", LastName = "Hackett", Salary = 2122.23m},
                new Teacher{FirstName = "Emaan", LastName = "Robin", Salary = 2522.23m},
                new Teacher{FirstName = "Dion", LastName = "Koch", Salary = 3122.23m},
            });

            context.SaveChanges();

            context.Students.AddRange(new[]
            {
                new Student {FirstName = "Mercy", LastName = "Beaumont", BirthDate = new DateTime(1992,01,21), Grade = 4.3},
                new Student {FirstName = "Neel", LastName = "Ibarra", BirthDate = new DateTime(1995,01,21), Grade = 5.3},
                new Student {FirstName = "Harmony", LastName = "Berger", BirthDate = new DateTime(1982,01,21), Grade = 5.5},
            });

            context.Courses.AddRange(new[]
            {
                new Course{Subject = "Math", TeacherId = 1,},
                new Course{Subject = "History", TeacherId = 1},
                new Course{Subject = "Biology", TeacherId = 3},
                new Course{Subject = "Chemistry", TeacherId = 2},
            });

            context.SaveChanges();

            for (int i = 1; i < 4; i++)
            {
                var course = context.Courses.FirstOrDefault(x => x.Id == i);
                course.Students.AddRange(context.Students.Skip(i - 1));
            }

            var teach = context.Teachers.FirstOrDefault(x => x.Id == 2);
            var corse = context.Courses.First();

            teach.Courses.Remove(corse);

            context.SaveChanges();

            var result = context.Courses.Where(x => x.TeacherId == 1).ToList();

            foreach (var item in result)
            {
                Console.WriteLine($"Subject: {item.Subject}, " +
                    $"Teacher: {item.Teacher.FirstName}, " +
                    $"Students: {string.Join(", ", item.Students.Select(x => x.FirstName))}");
            }
        }

    }
}
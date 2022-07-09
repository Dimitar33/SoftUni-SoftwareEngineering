using Microsoft.EntityFrameworkCore;

namespace enumTest.Models
{
    public class TestAppDbContext : DbContext
    {
        public TestAppDbContext(DbContextOptions options) 
            :base(options)
        {

        }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Answears> Answears { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Materials> Materials { get; set; }
        public DbSet<Modules> Modules { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Scores> Scores { get; set; }
        public DbSet<Userr> Userrs { get; set; }
        public DbSet<Vote> Votes { get; set; }
    }
}

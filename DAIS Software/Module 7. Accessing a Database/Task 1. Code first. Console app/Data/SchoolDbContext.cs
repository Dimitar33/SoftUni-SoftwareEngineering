using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1._Code_first._Console_app.Data.Models;

namespace Task_1._Code_first._Console_app.Data
{
    internal class SchoolDbContext : DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);


        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer("Server=.\\SQLEXPRESS;Database=School;Trusted_Connection=True;");
            }

            base.OnConfiguring(builder);
        }
    }
}

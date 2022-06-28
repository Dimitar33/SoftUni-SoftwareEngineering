using Invest_Team_Ltd.___ASP.NET_Web_API___jQuery_Assignment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invest_Team_Ltd.___ASP.NET_Web_API___jQuery_Assignment.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Problem> Problems { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Car>()
                .HasOne(p => p.Problem)
                .WithMany(c => c.Cars)
                .HasForeignKey(x => x.ProblemId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}

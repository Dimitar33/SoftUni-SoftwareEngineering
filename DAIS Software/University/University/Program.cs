//using BusinessLogic.Services;

using BusinessLogic.Services;
using BusinessLogic.Services.Interfaces;
using DataLayer.Data;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace University
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<UniversityContext>();
            builder.Services.AddTransient<IStudentsServices, StudentsServices>();
            builder.Services.AddTransient<ITeachersServices, TeachersServices>();
            builder.Services.AddTransient<IUserServices, UserServices>();
            builder.Services.AddTransient<ICourcesServices, CourcesServices>();
            builder.Services.AddTransient<UserData>();
            builder.Services.AddTransient<CoursesData>();
            builder.Services.AddTransient<StudentsData>();
            builder.Services.AddTransient<TeachersData>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.Run();
        }
    }
}
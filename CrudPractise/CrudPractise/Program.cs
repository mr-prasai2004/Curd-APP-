using Microsoft.EntityFrameworkCore;
using CrudPractise.Models;
namespace CrudPractise
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add DbContext with correct connection string name
            builder.Services.AddDbContext<Models.StudentDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("connstring")));

            // Add services to the container
            builder.Services.AddControllersWithViews();
            
            var app = builder.Build();

            // Configure the HTTP request pipeline
            app.UseStaticFiles(); // Serve static files like css, js, images, etc.
            app.UseRouting(); // Enable routing

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Students}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
using LearningPlatform.DAL.DB;
using LearningPlatform.DAL.Repository.Abstraction;
using LearningPlatform.DAL.Repository.Impelementation;
using Microsoft.EntityFrameworkCore;

namespace LearningPlatform.mvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            // Enhancement ConnectionString
            var connectionString = builder.Configuration.GetConnectionString("defaultConnection");

            builder.Services.AddDbContext<LearningPlatformDbContext>(options =>
            options.UseSqlServer(connectionString));

            builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();

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
                pattern: "{area=User}/{controller=Home}/{action=Index}/{id?}");
            app.MapControllerRoute(
                name: "User",
                pattern: "{area=User}/{controller=Category}/{action=Index}/{id?}");

            app.Run();
        }
    }
}

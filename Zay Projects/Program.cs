using Microsoft.EntityFrameworkCore;
using Zay_Projects.Data;

namespace Zay_Projects
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
            );  
            var app = builder.Build();
            app.MapControllerRoute(
          name: "areas",
          pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

          app.MapDefaultControllerRoute();
            app.UseStaticFiles();

            app.Run();

        }
    }
}
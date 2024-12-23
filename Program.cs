using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProductsMvc.Infrastructure.Data;

namespace ProductsMvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string connectionString = "Server=LAPTOP-M1H6FNPI\\MSSQLSERVER02; Database=ProductsMvc; Trusted_Connection=True; TrustServerCertificate=True;";

            builder.Services.AddDbContext<ProductsMvcDbContext>(options => options.UseSqlServer(connectionString));
            
            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddEntityFrameworkStores<ProductsMvcDbContext>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

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

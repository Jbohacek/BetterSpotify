using BetterSpotify.DataAccess.Data;
using BetterSpotify.DataAccess.Repository;
using BetterSpotify.DataAccess.Repository._IRepository;
using Microsoft.EntityFrameworkCore;

namespace BetterSpotifyWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Local -  Lok�ln� databaze, kter� je lok�ln�.
            //          Je pot�eba spustit sql script na dopln�n� testovac�ch dat
            //          Bude fungovat v�dy pokud je nainstalovan� "Ukl�d�n� a zpracov�n� dat"


            // AspifyConnetion - Databaze na internetu, kter� m� data

            var databaseName = "Local";

            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                builder.Configuration.GetConnectionString(databaseName)
                    ));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
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

            app.Run();
        }
    }
}
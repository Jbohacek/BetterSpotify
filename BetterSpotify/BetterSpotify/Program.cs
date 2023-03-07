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

            // Local -  Lokální databaze, která je lokálnì.
            //          Je potøeba spustit sql script na doplnìní testovacích dat
            //          Bude fungovat vždy pokud je nainstalovaná "Ukládání a zpracování dat"


            // AspifyConnetion - Databaze na internetu, která má data

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
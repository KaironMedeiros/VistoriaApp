using Microsoft.EntityFrameworkCore;
using VistoriaApp.Data;
using VistoriaApp.Repository;

namespace VistoriaApp
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            string connectionStrings = builder.Configuration.GetConnectionString("DataBase");

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();
            builder.Services.AddDbContext<VistoriaContext>(options => options.UseSqlServer(connectionStrings));
            builder.Services.AddScoped<IImovelRepositorio, ImovelRepositorio>();
            builder.Services.AddScoped<ILocatarioRepositorio, LocatarioRepositorio>();
            builder.Services.AddScoped<IVistoriadorRepositorio, VistoriadorRepositorio>();
            builder.Services.AddScoped<IAmbienteRepositorio, AmbienteRepositorio>();
            builder.Services.AddScoped<IVistoriaRepositorio, VistoriaRepositorio>();
            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

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
            app.UseAuthentication();;

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();
            app.Run();
        }
    }
}
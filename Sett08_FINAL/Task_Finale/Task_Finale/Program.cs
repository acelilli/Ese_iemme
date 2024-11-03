using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Task_Finale.Models;
using Task_Finale.Repos;
using Task_Finale.Services;

namespace Task_Finale
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            #region Context + Scoped + Authentication + Session Timeout
            builder.Services.AddDbContext<Task_FinaleContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseSQL")));

            builder.Services.AddScoped<UtenteRepo>();
            builder.Services.AddScoped<UtenteServices>();


            builder.Services.AddAuthentication().AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "Popolo",
                    ValidAudience = "Popolo", 
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("key_super_segretissima_con_tantissimissimi_caratteri"))
                };
            });

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });

            #endregion
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

            app.UseCors(builder => builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader());

            

            app.UseAuthentication();

            app.UseAuthorization();

            

            //usa sessione
            app.UseSession();

            // Aggiunta rotta principale al login
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Auth}/{action=Login}/{id?}");

            app.Run();
        }
    }
}

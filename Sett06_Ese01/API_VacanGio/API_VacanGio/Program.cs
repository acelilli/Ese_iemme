
using API_VacanGio.Context;
using API_VacanGio.Controllers;
using API_VacanGio.Repositories;
using API_VacanGio.Services;
using Microsoft.EntityFrameworkCore;

namespace API_VacanGio
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            #region BUILDRE CON IL CONTEXT
            builder.Services.AddDbContext<VaContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseTest")));
            /* --- REPOS --- */
            builder.Services.AddScoped<DestinazioneRepo>();
            builder.Services.AddScoped<RecensioneRepo>();
            builder.Services.AddScoped<PacchettoRepo>();
            /* --- SERVICES --- */
            builder.Services.AddScoped<DestinazioneServices>();

            /* --- CONTROLLERS (non vanno) -- */
            //builder.Services.AddScoped<DestinazioneController>();
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

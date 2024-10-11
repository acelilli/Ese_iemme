
using Microsoft.EntityFrameworkCore;
using Task_Ferramenta.Models;
using Task_Ferramenta.Repos;
using Task_Ferramenta.Services;

namespace Task_Ferramenta
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
            
            #region Stringa di connessione
            //specifica quale stringa di connessione e la avvia prima del programma
            builder.Services.AddDbContext<FerramentaContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseTest")));

            builder.Services.AddScoped<RepartoRepo>();
            builder.Services.AddScoped<ProdottoRepo>();
            builder.Services.AddScoped<RepartoServices>();
            builder.Services.AddScoped<ProdottoServices>();

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

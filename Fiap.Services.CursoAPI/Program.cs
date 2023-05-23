
using AutoMapper;
using Fiap.Services.CursoAPI.DbContexts;
using Fiap.Services.CursoAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Services.CursoAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //Add ConnectionString 

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer("Server=localhost;Database=FiapCursoAPI;TrustServerCertificate=True;User Id=sa;Password=fiap2022"));

            //Add mapping Dto with Model
            IMapper mapper = MappingConfig.RegistroMaps().CreateMapper();
            builder.Services.AddSingleton(mapper);
            builder.Services.AddAutoMapper(
                AppDomain.CurrentDomain.GetAssemblies());

            //Add Idependency Injection
            builder.Services.AddScoped<ICursoRepository, CursoRepository>();
            
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
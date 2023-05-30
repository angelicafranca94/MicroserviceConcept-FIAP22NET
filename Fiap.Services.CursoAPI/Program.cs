using AutoMapper;
using Fiap.Services.CursoAPI.DbContexts;
using Fiap.Services.CursoAPI.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Fiap.Services.CursoAPI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			// Adicionar a conexão
			builder.Services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer("Server=localhost;Database=FiapCursoAPI;Integrated Security=true;TrustServerCertificate=True"));

			// Adicionar o mapeamento da classe DTO com a Model
			IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
			builder.Services.AddSingleton(mapper);
			builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

			// Adicionar a injeçao de dependência
			builder.Services.AddScoped<ICursoRepository, CursoRepository>();

			builder.Services.AddControllers();

			builder.Services.AddAuthentication("Bearer")
				.AddJwtBearer("Bearer", options =>
				{

					options.Authority = "https://localhost:7000/";
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateAudience = false
					};

				});

			builder.Services.AddAuthorization(options =>
			{
				options.AddPolicy("ApiScope", policy =>
				{
					policy.RequireAuthenticatedUser();
					policy.RequireClaim("scope", "fiap");
				});
			});


			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			
			// Congifurar o security (token) na documentação do swagger
			builder.Services.AddSwaggerGen(doc =>
			{
				doc.SwaggerDoc("v1", new OpenApiInfo { Title = "Fiap.Services.CursoAPI", Version = "v1" });
				doc.EnableAnnotations();
				doc.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					Description = @"Entre com o formato 'Bearer' + [space] + e seu token",
					Name = "Authorization",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.ApiKey,
					Scheme = "Bearer"
				});

				doc.AddSecurityRequirement(new OpenApiSecurityRequirement {
					{
						new OpenApiSecurityScheme
						{
							Reference = new OpenApiReference
							{
								Type=ReferenceType.SecurityScheme,
								Id="Bearer"
							},
							Scheme="oauth2",
							Name="Bearer",
							In=ParameterLocation.Header
						},
						new List<string>()
					}
				});
			});

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(doc => doc.SwaggerEndpoint("/swagger/v1/swagger.json", "Fiap.Services.CursoAPI v1"));
			}

			app.UseHttpsRedirection();

			// Invocar os serviços de autenticação 
			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}
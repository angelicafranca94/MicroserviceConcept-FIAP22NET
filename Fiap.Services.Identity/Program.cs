using Duende.IdentityServer.AspNetIdentity;
using Duende.IdentityServer.Services;
using Fiap.Services.Identity.DbContexts;
using Fiap.Services.Identity.Initializer;
using Fiap.Services.Identity.Models;
using Fiap.Services.Identity.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace Fiap.Services.Identity
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			// Adicionar a conexão
			builder.Services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer("Server=localhost;Database=FiapIdentityServer;Integrated Security=true;TrustServerCertificate=True"));

			// Adicionar a injeçao de dependência
			builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

			var builderIdentity = builder.Services.AddIdentityServer(options =>
			{
				options.Events.RaiseErrorEvents = true;
				options.Events.RaiseInformationEvents = true;
				options.Events.RaiseFailureEvents = true;
				options.Events.RaiseSuccessEvents = true;
				options.EmitStaticAudienceClaim = true;
			}).AddInMemoryIdentityResources(SD.IdentityResources)
			.AddInMemoryApiScopes(SD.ApiScopes)
			.AddInMemoryClients(SD.Clients)
			.AddAspNetIdentity<ApplicationUser>();

			builder.Services.AddScoped<IDbInitializer, DbInitializer>();
			builder.Services.AddScoped<IProfileService, ProfileService>();

			builderIdentity.AddDeveloperSigningCredential();

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

			// Adicionar o IdentityServer
			app.UseIdentityServer();

			var scope = app.Services.CreateScope();
			var dbInitializer = scope.ServiceProvider.GetService<IDbInitializer>();

			if (dbInitializer != null) { 
				dbInitializer.Initialize();
			}

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
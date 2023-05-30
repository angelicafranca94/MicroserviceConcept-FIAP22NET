using Fiap.Web.Services;
using Fiap.Web.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace Fiap.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Http Client
            builder.Services.AddHttpClient<ICursoService, CursoService>();
            builder.Services.AddHttpClient<ICarrinhoService, CarrinhoService>();
            builder.Services.AddHttpClient<IPromocaoService, PromocaoService>();
            SD.CursoAPIBase = builder.Configuration["ServiceUrls:CursoAPI"];
            SD.CarrinhoAPIBase = builder.Configuration["ServiceUrls:CarrinhoAPI"];
            SD.PromocaoAPIBase = builder.Configuration["ServiceUrls:PromocaoAPI"];

            // Add Injeção de dependência
            builder.Services.AddScoped<ICursoService, CursoService>();
            builder.Services.AddScoped<ICarrinhoService, CarrinhoService>();
            builder.Services.AddScoped<IPromocaoService, PromocaoService>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Adicionar configuração do authentication
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
                .AddCookie("Cookies", c => c.ExpireTimeSpan = TimeSpan.FromMinutes(10))
                .AddOpenIdConnect("oidc", options =>
                {
                    options.Authority = builder.Configuration.GetSection("ServiceUrls").GetValue<string>("IdentityAPI");
                    options.GetClaimsFromUserInfoEndpoint = true;
                    options.ClientId = "fiap";
                    options.ClientSecret = "secret";
                    options.ResponseType = "code";
                    options.ClaimActions.MapJsonKey("role", "role", "role");
                    options.ClaimActions.MapJsonKey("sub", "sub", "sub");
                    options.TokenValidationParameters.NameClaimType = "name";
                    options.TokenValidationParameters.RoleClaimType = "role";
                    options.Scope.Add("fiap");
                    options.SaveTokens = true;

                });

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
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
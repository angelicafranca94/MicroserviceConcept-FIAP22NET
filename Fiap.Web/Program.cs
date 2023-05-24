using Fiap.Web.Services;
using Fiap.Web.Services.IServices;

namespace Fiap.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            //HttpClient
            builder.Services.AddHttpClient<ICursoService, CursoService>();
            SD.CursoAPIBase = builder.Configuration["ServiceUrls:CursoAPI"];

            //Add Dependency Injection
            builder.Services.AddScoped<ICursoService, CursoService>();

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
                    options.RequireHttpsMetadata = false;
                    options.Authority = builder.Configuration["ServiceUrls:IdentityAPI"];
                    options.GetClaimsFromUserInfoEndpoint = true;
                    options.ClientId = "fiap";
                    options.ClientSecret = "secret";
                    options.ResponseType = "code";
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
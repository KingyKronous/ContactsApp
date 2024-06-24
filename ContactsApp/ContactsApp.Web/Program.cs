using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ContactsApp.Web.Models;
using ContactsApp.Shared.Extensions;
using ContactsApp.Services;
using ContactsApp.Data.Repos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using ContactsApp.Shared.Security.Contracts;
using ContactsApp.Shared.Security;
using ContactsApp.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
namespace ContactsApp.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //IJwtSettings settings = builder.Configuration.GetSection(typeof(JwtSettings).Name).Get<JwtSettings>();

            /*builder.Services.AddAuthentication(cfg => cfg.DefaultScheme = JwtBearerDefaults.AuthenticationScheme)
                //.AddCookie();
                            .AddJwtBearer(options =>
                            {
                                if (options.SecurityTokenValidators.FirstOrDefault() is JwtSecurityTokenHandler jwtSecurityTokenHandler)
                                {
                                    jwtSecurityTokenHandler.MapInboundClaims = false;
                                }
                                options.RequireHttpsMetadata = false;
                                options.SaveToken = true;
                                options.TokenValidationParameters = new TokenValidationParameters
                                {
                                    ValidateIssuer = true,
                                    ValidateAudience = true,
                                    ValidateLifetime = true,
                                    ValidateIssuerSigningKey = true,
                                    ValidIssuer = settings.Issuer,
                                    ValidAudience = settings.Audience,
                                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Key)),
                                    NameClaimType = JwtRegisteredClaimNames.Sub
                                };
                                options.Events = new JwtBearerEvents
                                {
                                    OnMessageReceived = context =>
                                    {
                                        var accessToken = context.Request.Query["access_token"];

                                        // If the request is for our hub...
                                        var path = context.HttpContext.Request.Path;
                                        if (!string.IsNullOrEmpty(accessToken) &&
                                            (path.StartsWithSegments("/chathub")))
                                        {
                                            // Read the token out of the query string
                                            context.Token = accessToken;
                                        }
                                        return Task.CompletedTask;
                                    }
                                };
                            });*/

            //builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                //.AddCookie();

            //builder.Services.AddSingleton(settings);


            /*builder.Services.AddDbContext<ContactsAppWebContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ContactsAppWebContext") ?? throw new InvalidOperationException("Connection string 'ContactsAppWebContext' not found.")));*/

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ContactsAppWebContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ContactsAppWebContext") ?? throw new InvalidOperationException("Connection string 'ContactsAppWebContext' not found.")));

            builder.Services.AddAutoMapper(m => m.AddProfile(new AutoMapperConfiguration()));

            builder.Services.AutoBind(typeof(ContactsService).Assembly);
            builder.Services.AutoBind(typeof(ContactRepository).Assembly);
            builder.Services.AutoBind(typeof(GroupsService).Assembly);
            builder.Services.AutoBind(typeof(GroupRepository).Assembly);
            builder.Services.AutoBind(typeof(UsersService).Assembly);
            builder.Services.AutoBind(typeof(UserRepository).Assembly);
            builder.Services.AutoBind(typeof(RolesService).Assembly);
            builder.Services.AutoBind(typeof(RoleRepository).Assembly);


            IJwtSettings settings = builder.Configuration.GetSection(typeof(JwtSettings).Name).Get<JwtSettings>();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie();

            builder.Services.AddSingleton(settings);


            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                //var services = scope.ServiceProvider;
                var services = scope.ServiceProvider.GetRequiredService<ContactsAppWebContext>();

                //Automatically update database 
                services.Database.Migrate();

                //SeedData.Initialize(services);
            }

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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}

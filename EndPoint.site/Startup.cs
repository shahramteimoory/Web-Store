using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using Web_Store.Application.Interfaces.Contexts;
using Web_Store.Application.Interfaces.FacadPatterns;
using Web_Store.Application.Services.Products.FacadPattern;
using Web_Store.Application.Services.Users.Commands.EditUser;
using Web_Store.Application.Services.Users.Commands.RegisterUser;
using Web_Store.Application.Services.Users.Commands.RemoveUser;
using Web_Store.Application.Services.Users.Commands.UserLogin;
using Web_Store.Application.Services.Users.Commands.UserStatusChange;
using Web_Store.Application.Services.Users.Queries.GetRoles;
using Web_Store.Application.Services.Users.Queries.GetUsers;
using Web_Store.Persistance.Contexts;

namespace EndPoint.site
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
                options.LoginPath = new PathString("/");
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5.0);
            });



            services.AddScoped<IDataBaseContext, DataBaseContext>();
            services.AddScoped<IGetUserService, GetUserService>();
            services.AddScoped<IGetRolesService, GetRolesService>();
            services.AddScoped<IRegisterUserService,RegisterUserService>();
            services.AddScoped<IRemoveUserService, RemoveUserService>();
            services.AddScoped<IUserStatusChangeService, UserStatusChangeService>();
            services.AddScoped<IEditUserService, EditUserService>();
            services.AddScoped<IUserLoginService, UserLoginService>();


            //facad Inject be jaye in ke mesl bala 8 ta inject konim 
            services.AddScoped<IProductFacad, ProductFacad>();

            string connectionString = "Data Source=DESKTOP-GSQBNGV ; Initial Catalog=Web-StoreDB;Integrated Security=true;";
            services.AddEntityFrameworkSqlServer().AddDbContext<DataBaseContext>(Options=>Options.UseSqlServer(connectionString));
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
            name: "areas",
                 pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"); 
            });


        }
    }
}

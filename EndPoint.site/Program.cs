using EndPoint.site.Utilities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Web_Store.Application.Interfaces.Contexts;
using Web_Store.Application.Interfaces.FacadPatterns;
using Web_Store.Application.Services.Carts;
using Web_Store.Application.Services.Common.FacadPattern;
using Web_Store.Application.Services.Finances.FacadPattern;
using Web_Store.Application.Services.HomePage.FacadPattern;
using Web_Store.Application.Services.Orders.FacadPattern;
using Web_Store.Application.Services.Products.FacadPattern;
using Web_Store.Application.Services.Users.Commands.EditUser;
using Web_Store.Application.Services.Users.Commands.RegisterUser;
using Web_Store.Application.Services.Users.Commands.RemoveUser;
using Web_Store.Application.Services.Users.Commands.UserLogin;
using Web_Store.Application.Services.Users.Commands.UserStatusChange;
using Web_Store.Application.Services.Users.Queries.GetRoles;
using Web_Store.Application.Services.Users.Queries.GetUsers;
using Web_Store.Common.Roles;
using Web_Store.Persistance.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthorization(Options =>
{
    Options.AddPolicy(UserRole.Admin, policy => policy.RequireRole(UserRole.Admin));
    Options.AddPolicy(UserRole.Operator, policy => policy.RequireRole(UserRole.Operator));
    Options.AddPolicy(UserRole.Customer, policy => policy.RequireRole(UserRole.Customer));
});


builder.Services.AddAuthentication(options =>
{
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
{
    options.LoginPath = new PathString("/Authentication/Signin");
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5.0);
    options.AccessDeniedPath = new PathString("/");
});



builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
builder.Services.AddScoped<IGetUserService, GetUserService>();
builder.Services.AddScoped<IGetRolesService, GetRolesService>();
builder.Services.AddScoped<IRegisterUserService, RegisterUserService>();
builder.Services.AddScoped<IRemoveUserService, RemoveUserService>();
builder.Services.AddScoped<IUserStatusChangeService, UserStatusChangeService>();
builder.Services.AddScoped<IEditUserService, EditUserService>();
builder.Services.AddScoped<IUserLoginService, UserLoginService>();


//facad Inject be jaye in ke mesl bala 8 ta inject konim 
builder.Services.AddScoped<IProductFacad, ProductFacad>();
builder.Services.AddScoped<ICommonFacad, CommonFacad>();
builder.Services.AddScoped<IHomePageFacad, HomePageFacad>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<CookiesManeger, CookiesManeger>();
builder.Services.AddScoped<IFinancesFacad, FinancesFacad>();
builder.Services.AddScoped<IOrdersFacad, OrdersFacad>();


string connectionString = "Data Source=DESKTOP-GSQBNGV ; Initial Catalog=Web-StoreDB;Integrated Security=true;";
builder.Services.AddEntityFrameworkSqlServer().AddDbContext<DataBaseContext>(Options => Options.UseSqlServer(connectionString));
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
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

app.Run();

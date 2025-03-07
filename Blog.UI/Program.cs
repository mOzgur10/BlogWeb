using Microsoft.EntityFrameworkCore;
using Blog.Dal.Context;
using Blog.Service.Interfaces;
using Blog.Service.Concrete;
using Blog.Dal.Repos.Concrete;
using Blog.Dal.Repos.Interfaces;
using Blog.Data.Concrete;
using Microsoft.AspNetCore.Identity;

namespace Blog.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddScoped<IArticleService, ArticleService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
            builder.Services.AddScoped<IArticleRepo, ArticleRepo>();

            builder.Services.AddSession();
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConn")));

            builder.Services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = false;
            })
                .AddRoleManager<RoleManager<AppRole>>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
            builder.Services.ConfigureApplicationCookie(config =>
            {
                config.LoginPath = new PathString("/User/Login");
                config.LogoutPath = new PathString("/User/Logout");
                config.Cookie = new CookieBuilder()
                {
                    Name="BlogSitesi",
                    HttpOnly=true,
                    SameSite=SameSiteMode.Strict,
                    SecurePolicy = CookieSecurePolicy.SameAsRequest
                };
                config.SlidingExpiration = true;
                config.ExpireTimeSpan = TimeSpan.FromDays(1);
                config.AccessDeniedPath = new PathString("/User/AccessDenied");
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
            app.UseSession();
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
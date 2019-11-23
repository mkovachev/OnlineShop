using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineShop.Data.Models;
using System.Threading.Tasks;

namespace OnlineShop.Web.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                app.UseHsts();
            }

            return app;
        }

        public static IApplicationBuilder UseEndpoints(this IApplicationBuilder app)
               => app.UseEndpoints(routes =>
               {
                   routes.MapControllerRoute(
                       name: "default",
                       pattern: "{controller=Home}/{action=Index}/{id?}");
                   routes.MapRazorPages();

                   routes.MapControllerRoute(
                      name: "areas",
                       pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                   routes.MapRazorPages();
               });

        public static async Task<IApplicationBuilder> SeedDataAsync(this IApplicationBuilder app)
        {
            using (IServiceScope serviceScope = app.ApplicationServices.CreateScope())
            {
                System.IServiceProvider services = serviceScope.ServiceProvider;

                OnlineShopDbContext db = services.GetService<OnlineShopDbContext>();

                //await db.Database.MigrateAsync();

                RoleManager<IdentityRole> roleManager = services.GetService<RoleManager<IdentityRole>>();
                IdentityRole existingRole = await roleManager.FindByNameAsync(WebConstants.AdministratorRole);

                if (existingRole != null)
                {
                    return app;
                }

                IdentityRole adminRole = new IdentityRole(WebConstants.AdministratorRole);

                await roleManager.CreateAsync(adminRole);

                User admin = new User
                {
                    UserName = "admin",
                    Email = "admin@onlineshop.com",
                };

                UserManager<User> userManager = services.GetService<UserManager<User>>();

                await userManager.CreateAsync(admin, "adminpass");

                await userManager.AddToRoleAsync(admin, WebConstants.AdministratorRole);

                User user = new User
                {
                    UserName = "user",
                    Email = "user@onlineshop.com",
                };

                await userManager.CreateAsync(user, "userpass");

                await db.SaveChangesAsync();
            }

            return app;
        }
        public static IApplicationBuilder SeedData(this IApplicationBuilder app) => app.SeedDataAsync().GetAwaiter().GetResult();
    }
}
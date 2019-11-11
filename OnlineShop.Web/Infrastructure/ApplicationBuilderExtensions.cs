using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineShop.Controllers;
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
                => app.UseEndpoints(endpoints =>
                    {
                        endpoints.MapControllerRoute(
                            name: "default",
                            pattern: "{controller=Home}/{action=Index}/{id?}");
                        endpoints.MapRazorPages();
                    });

        public static async Task<IApplicationBuilder> SeedDataAsync(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                var dbContext = services.GetService<OnlineShopDbContext>();

                await dbContext.Database.MigrateAsync();

                var roleManager = services.GetService<RoleManager<IdentityRole>>();
                var existingRole = await roleManager.FindByNameAsync(ControllerValidations.AdministratorRole);
                if (existingRole != null)
                {
                    return app;
                }

                var adminRole = new IdentityRole(ControllerValidations.AdministratorRole);

                await roleManager.CreateAsync(adminRole);

                // create user
                //var adminUser = new User
                //{
                //    UserName = "admin@onlineshop.com",
                //    Email = "admin@onlineshop.com",
                //    SecurityStamp = "AdminsecurityStamp"
                //};

                //var userManager = services.GetService<UserManager<User>>();

                //await userManager.CreateAsync(adminUser, "adminpass");

                //await userManager.AddToRoleAsync(adminUser, ControllerValidations.AdministratorRole);

                //var user = new User
                //{
                //    UserName = "normal@onlineshop.com",
                //    Email = "normal@onlineshop.com",
                //    SecurityStamp = "UserSecurityStamp"
                //};

                //await userManager.CreateAsync(user, "userpass");

                await dbContext.SaveChangesAsync();
            }

            return app;
        }
    }
}
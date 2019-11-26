using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineShop.Controllers;
using OnlineShop.Data.Models;
using System;
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
                      name: "areas",
                       pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                   routes.MapRazorPages();

                   routes.MapControllerRoute(
                       name: "default",
                       pattern: "{controller=Home}/{action=Index}/{id?}");
                   routes.MapRazorPages();
               });

        public static async Task<IApplicationBuilder> SeedDataAsync(this IApplicationBuilder app)
        {
            using (IServiceScope serviceScope = app.ApplicationServices.CreateScope())
            {
                IServiceProvider services = serviceScope.ServiceProvider;

                OnlineShopDbContext db = services.GetService<OnlineShopDbContext>();

                await db.Database.MigrateAsync();

                RoleManager<IdentityRole> roleManager = services.GetService<RoleManager<IdentityRole>>();

                //create role = "Administrator"
                if (!await roleManager.RoleExistsAsync(ControllerConstants.AdministratorRole))
                {
                    IdentityRole adminRole = new IdentityRole(ControllerConstants.AdministratorRole);
                    await roleManager.CreateAsync(adminRole);
                }

                UserManager<IdentityUser> userManager = services.GetService<UserManager<IdentityUser>>();

                // create admin for testing
                if (await userManager.FindByNameAsync("admin") == null)
                {
                    User admin = new User
                    {
                        UserName = "admin",
                        Email = "admin@onlineshop.com"
                    };

                    await userManager.CreateAsync(admin, "adminpass");
                    await userManager.AddToRoleAsync(admin, ControllerConstants.AdministratorRole);
                }

                // create user for testing
                if (await userManager.FindByNameAsync("user") == null)
                {
                    User user = new User
                    {
                        UserName = "user",
                        Email = "user@onlineshop.com"
                    };
                    await userManager.CreateAsync(user, "userpass");
                }

                // create category for testing
                var testCategory = new Category
                {
                    //Id = 1,
                    Name = "Snowboard"
                };

                await db.Categories.AddAsync(testCategory);

                // create product for testing
                    var testProduct = new Product
                    {
                        Title = "TestProduct",
                        Price = 12,
                        //CategoryId = testCategory.Id 
                    };
                await db.Products.AddAsync(testProduct);

                await db.SaveChangesAsync();
            }

            return app;
        }
        public static IApplicationBuilder SeedData(this IApplicationBuilder app) => app.SeedDataAsync().GetAwaiter().GetResult();
    }
}
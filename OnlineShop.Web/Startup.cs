using AutoMapper;
using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Controllers.Implementations;
using OnlineShop.Services.Infrastructure;
using OnlineShop.Services.Interfaces;
using OnlineShop.Services.Models.ShoppingCartService;
using OnlineShop.Web.Infrastructure;
using System;
using System.Collections.Generic;

namespace OnlineShop.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddDbContext<OnlineShopDbContext>(options
                => options.UseSqlServer(Configuration.GetDefaultConnectionString()));

            services
                .AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddDefaultUI()
                .AddEntityFrameworkStores<OnlineShopDbContext>();

            services.AddAutoMapper(
                typeof(IService).Assembly,
                typeof(HomeController).Assembly);

            services
               .Configure<IdentityOptions>(options =>
               {
                   options.Password.RequireDigit = false;
                   options.Password.RequiredLength = 6;
                   options.Password.RequireLowercase = false;
                   options.Password.RequireNonAlphanumeric = false;
                   options.Password.RequireUppercase = false;
               });

            services.AddServices(); // auto reg all services

            // add Shopping cart
            services.AddSingleton(sp => new ShoppingCart() { Id = Guid.NewGuid().ToString(), ShoppingCartItems = new List<ShoppingCartItem>() });

            // add email services
            //services.AddSingleton<IEmailConfiguration>(Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>());
            //services.AddTransient<IEmailService, EmailService>();

            services
                .AddMvc(options => options
                    .AddAutoValidateAntiforgeryToken())
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddRouting(routing => { routing.LowercaseUrls = true; }); // routing lowercase

            //services.AddSession(options =>  // session
            //{
            //    options.IdleTimeout = TimeSpan.FromSeconds(30);
            //});

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandling(env);

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints();

            app.SeedData();
        }
    }
}
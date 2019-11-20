using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data.Models;
using System;

namespace Data
{
    public class OnlineShopDbContext : IdentityDbContext<IdentityUser>
    {
        public OnlineShopDbContext(DbContextOptions<OnlineShopDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<ShippingDetail> ShippingDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>().ToTable("Products");
            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<Order>().ToTable("Orders");
            builder.Entity<OrderDetail>().ToTable("OrderDetails");
            builder.Entity<ShippingDetail>().ToTable("ShippingDetails");
            builder.Entity<Image>().ToTable("Images");

            //builder.Entity<OrderDetail>()
            //    .HasOne(od => od.Order)
            //    .WithMany(o => o.OrderDetails)
            //    .HasForeignKey(od => od.OrderId);

            //builder.Entity<ShippingDetail>()
            // .HasOne(od => od.Order)
            // .WithMany(o => o.ShippingDetails)
            // .HasForeignKey(od => od.OrderId);

            //builder
            //    .Entity<Order>()
            //    .HasOne(a => a.User)
            //    .WithMany(u => u.Orders)
            //    .HasForeignKey(a => a.UserId);

            base.OnModelCreating(builder);
        }
    }
}
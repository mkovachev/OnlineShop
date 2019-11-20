using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data.Models;

namespace Data
{
    public class OnlineShopDbContext : IdentityDbContext
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
            // .HasOne(sd => sd.Order)
            // .WithMany(o => o.ShippingDetails)
            // .HasForeignKey(sd => sd.OrderId);

            //builder
            //    .Entity<Order>()
            //    .HasOne(o => o.User)
            //    .WithMany(u => u.Orders)
            //    .HasForeignKey(o => o.UserId);

            //builder.Entity<Image>()
            //    .HasOne(i => i.Product)
            //    .WithMany(p => p.Images)
            //    .HasForeignKey(i => i.Product);

            base.OnModelCreating(builder);
        }
    }
}
using AutoMapper;
using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data.Models;
using OnlineShop.Services.Models.ProductService;
using OnlineShop.Services.Models.ShoppingCartService;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Test
{
    public static class Startup
    {
        public static Mapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps("OnlineShop.Data");
                cfg.AddMaps("OnlineShop.Services");
                cfg.AddMaps("OnlineShop.Web");
                cfg.CreateMap<Product, ProductListingServiceModel>();
            });

            var mapper = new Mapper(config);

            return mapper;
        }
        public static Category CreateCategory()
            => new Category
            {
                Id = 1,
                Name = "Snowboard",
                Products = new List<Product>()
            };
        public static List<Product> CreateProducts()
            => new List<Product>()
            {
                new Product { Id = 1, Title = "TestProduct1", Price = 1, CategoryId = 1 },
                new Product { Id = 2, Title = "TestProduct2", Price = 1, CategoryId = 1 },
                new Product { Id = 3, Title = "TestProduct3", Price = 1, CategoryId = 1 }
            };
        public static Order CreateOrder()
            => new Order
            {
                Id = 1
            };
        public static OrderDetail CreateOrderDetails()
          => new OrderDetail
          {
              Id = "1",
              OrderId = 1,
              OrderPlaced = DateTime.MinValue
          };
        public static OnlineShopDbContext CreateDatabase()
        {
            var dbOptions = new DbContextOptionsBuilder<OnlineShopDbContext>()
                               .UseInMemoryDatabase(Guid.NewGuid().ToString())
                               .Options;
            var db = new OnlineShopDbContext(dbOptions);

            db.Categories.Add(CreateCategory());
            db.Products.AddRange(CreateProducts());
            db.Orders.Add(CreateOrder());
            db.OrderDetails.Add(CreateOrderDetails());
            db.SaveChanges();

            return db;
        }
        public static ShoppingCart CreateShoppingCart()
        {
            var shoppingCart = new ShoppingCart()
            {
                Id = "1",
                ShoppingCartItems = new List<ShoppingCartItem>()
            };

            return shoppingCart;
        }

        public static void SetString(this ISession session, string key, string value)
        {
            session.Set(key, Encoding.UTF8.GetBytes(value));
        }

        public static string GetString(this ISession session, string key)
        {
            var data = session.Get(key);
            if (data == null)
            {
                return null;
            }
            return Encoding.UTF8.GetString(data);
        }

        public static byte[] Get(this ISession session, string key)
        {
            session.TryGetValue(key, out byte[] value);
            return value;
        }
    }
}

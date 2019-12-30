using Data;
using FluentAssertions;
using OnlineShop.Data.Models;
using OnlineShop.Services.Implementations;
using OnlineShop.Services.Models.ShoppingCartService;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace OnlineShop.Test.Services
{
    public class ShoppingCartServiceTest
    {
        private readonly OnlineShopDbContext db;
        private readonly ShoppingCart shoppingCart;
        private readonly List<Product> products;

        public ShoppingCartServiceTest()
        {
            this.db = TestStartup.CreateDatabase();
            this.shoppingCart = TestStartup.CreateShoppingCart();
            this.products = this.db.Products.ToList();
        }

        [Fact]
        public void AllProducts_ShouldReturn_AllProductsInCart()
        {
            // Arrrange
            var shoppingCartService = new ShoppingCartService(db, shoppingCart);

            var item = new ShoppingCartItem()
            {
                Id = "1",
                Product = products.First(),
                ShoppingCartId = "1"
            };

            this.shoppingCart.ShoppingCartItems.Add(item);

            // Act
            var items = shoppingCartService.AllProducts();

            // Assert
            items
                .Should()
                .Match(r => r.ElementAt(0).Product.Title == "TestProduct1")
                .And
                .HaveCount(1);
        }

        [Fact]
        public void AddToCart_ShoulAdd_ProductToCart()
        {
            // Arrrange
            var shoppingCartService = new ShoppingCartService(db, this.shoppingCart);

            var product = new Product { Id = 1, Price = 1, Title = "TestProduct" };

            // Act
            shoppingCartService.AddToCart(product, 1);

            var result = this.shoppingCart
                                .ShoppingCartItems
                                .FirstOrDefault(p => p.Product.Title == "TestProduct");

            // Arrange
            result.Should().NotBeNull();
            result
                .Should()
                .Match<ShoppingCartItem>(p => p.Product.Id == 1
                                                && p.Product.Title == "TestProduct"
                                                && p.Product.Price == 1);
        }
    }
}

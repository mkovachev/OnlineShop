using Data;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data.Models;
using OnlineShop.Services.Interfaces;
using OnlineShop.Services.Models.ShoppingCartService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Services.Implementations
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly OnlineShopDbContext db;
        private readonly ShoppingCart shoppingCart;

        public ShoppingCartService(OnlineShopDbContext db, ShoppingCart shoppingCart)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
            this.shoppingCart = shoppingCart ?? throw new ArgumentNullException(nameof(shoppingCart));
        }

        public async Task<Product> FindProductByIdAsync(int productId)
            => await this.db.Products.FirstOrDefaultAsync(s => s.Id == productId);

        public List<ShoppingCartItem> AllProducts()
            => this.shoppingCart
                       .ShoppingCartItems
                       .Where(c => c.ShoppingCartId == shoppingCart.Id)
                       .ToList();

        public void AddToCart(Product product, int amount)
        {
            var shoppingCartItem = this.shoppingCart
                                        .ShoppingCartItems
                                        .Where(c => c.ShoppingCartId == shoppingCart.Id
                                                        && c.Product.Id == product.Id)
                                        .FirstOrDefault();

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    Id = Guid.NewGuid().ToString(),
                    ShoppingCartId = shoppingCart.Id,
                    Product = product,
                    Price = 1
                };

                this.shoppingCart.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Price++;
            }
            return;
        }

        public void RemoveProduct(Product product)
        {
            var shoppingCartItem = this.shoppingCart
                                        .ShoppingCartItems
                                        .Where(s => s.Product.Id == product.Id
                                                   && s.ShoppingCartId == shoppingCart.Id)
                                         .FirstOrDefault();

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Price > 1)
                {
                    shoppingCartItem.Price--;
                }
                else
                {
                    this.shoppingCart.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }
        }

        public void ClearCart()
        {
            this.shoppingCart.ShoppingCartItems.Clear();
        }

        public decimal GetTotal()
            => this.shoppingCart
                       .ShoppingCartItems
                       .Where(c => c.ShoppingCartId == shoppingCart.Id)
                       .Select(c => c.Product.Price * c.Price)
                       .Sum();
    }
}

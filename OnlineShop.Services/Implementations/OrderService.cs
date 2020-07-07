using Data;
using OnlineShop.Data.Models;
using OnlineShop.Services.Interfaces;
using OnlineShop.Services.Models.ShoppingCartService;
using System;
using System.Threading.Tasks;

namespace OnlineShop.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly OnlineShopDbContext db;
        private readonly ShoppingCart shoppingCart;

        public OrderService(OnlineShopDbContext db, ShoppingCart shoppingCart)
        {
            this.db = db;
            this.shoppingCart = shoppingCart;
        }

        public async Task CreateOrderAsync(Order order)
        {
            await this.db.Orders.AddAsync(order);

            var shoppingCartItems = this.shoppingCart.ShoppingCartItems;

            foreach (var product in shoppingCartItems)
            {
                var orderDetail = new OrderDetail // TODO
                {
                    //Amount = product.Amount,
                    //ProductId = product.Product.Id,
                    //Price = product.Product.Price,
                    OrderId = order.Id,
                    OrderPlaced = DateTime.UtcNow
                };

                await this.db.OrderDetails.AddAsync(orderDetail);

                await this.db.SaveChangesAsync();
            }

        }
    }
}

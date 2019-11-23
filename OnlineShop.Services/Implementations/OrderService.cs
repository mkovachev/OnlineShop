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
        private readonly IDateTimeProvider dateTimeProvider;

        public OrderService(OnlineShopDbContext db, ShoppingCart shoppingCart, IDateTimeProvider dateTimeProvider)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
            this.shoppingCart = shoppingCart ?? throw new ArgumentNullException(nameof(shoppingCart));
            this.dateTimeProvider = dateTimeProvider ?? throw new ArgumentNullException(nameof(dateTimeProvider));
        }

        public async Task CreateOrderAsync(Order order)
        {
            order.CreatedOn = this.dateTimeProvider.UtcNow();

            await this.db.Orders.AddAsync(order);

            var shoppingCartItems = this.shoppingCart.ShoppingCartItems;

            foreach (var item in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {

                    ProductPrice = item.Price,
                    Id = item.Id,
                    OrderId = order.Id
                };

                await this.db.OrderDetails.AddAsync(orderDetail);

                await this.db.SaveChangesAsync();
            }

        }
    }
}

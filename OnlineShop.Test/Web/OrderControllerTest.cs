using Data;
using OnlineShop.Data.Models;
using OnlineShop.Services.Implementations;
using OnlineShop.Services.Models.ShoppingCartService;
using System.Threading.Tasks;
using Xunit;

namespace OnlineShop.Test.Web
{
    public class OrderControllerTest
    {
        private readonly OnlineShopDbContext db;
        private readonly ShoppingCart shoppingCart;

        public OrderControllerTest()
        {
            this.db = TestStartup.CreateDatabase();
            this.shoppingCart = TestStartup.CreateShoppingCart();
        }

        [Fact]
        public async Task Checkout_ShouldCreate_Order()
        {
            // Arrange
            var orderService = new OrderService(db, shoppingCart);

            var order = new Order
            {
                Id = 2
            };

            // Act
            await orderService.CreateOrderAsync(order);

            var savedOrder = await this.db.Orders.FindAsync(order.Id);

            // Assert
            Assert.NotNull(savedOrder);
        }
    }
}

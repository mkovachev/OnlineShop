using Data;
using OnlineShop.Data.Models;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace OnlineShop.Test.Services
{
    public class OrderServiceTest
    {
        private readonly OnlineShopDbContext db;
        private readonly Order order;
        private readonly OrderDetail orderDetail;

        public OrderServiceTest()
        {
            this.db = TestStartup.CreateDatabase();
            this.order = this.db.Orders.FirstOrDefault();
            this.orderDetail = this.db.OrderDetails.FirstOrDefault();
        }

        [Fact]
        public async Task CreateOrderAsync_ShouldSave_Order()
        {
            // Act
            var savedOrder = await this.db.Orders.FindAsync(order.Id);

            // Assert
            Assert.NotNull(savedOrder);
        }

        [Fact]
        public async Task CreateOrderAsync_ShouldSave_OrderDetails()
        {
            var orderDetails = await this.db.OrderDetails.FindAsync(orderDetail.Id);

            // Assert
            Assert.NotNull(orderDetails);
        }
    }
}

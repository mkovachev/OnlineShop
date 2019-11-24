using OnlineShop.Data.Models;
using OnlineShop.Services.Common;
using System.Threading.Tasks;

namespace OnlineShop.Services.Interfaces
{
    public interface IOrderService : IService
    {
        Task CreateOrderAsync(Order order);
    }
}

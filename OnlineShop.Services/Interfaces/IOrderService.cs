using OnlineShop.Data.Models;
using System.Threading.Tasks;

namespace OnlineShop.Services.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrderAsync(Order order);
    }
}

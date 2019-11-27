using OnlineShop.Data.Models;
using OnlineShop.Services.Common;
using System.Threading.Tasks;

namespace OnlineShop.Services.Interfaces
{
    public interface IOrderService : ITransientService
    {
        Task CreateOrderAsync(Order order);
    }
}

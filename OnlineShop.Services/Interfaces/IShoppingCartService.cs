using OnlineShop.Data.Models;
using OnlineShop.Services.Common;
using OnlineShop.Services.Models.ShoppingCartService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Services.Interfaces
{
    public interface IShoppingCartService : IScopedService
    {
        Task<Product> FindProductByIdAsync(int productId);

        void AddToCart(Product product, int quantity);

        void RemoveProduct(Product product);

        void ClearCart();

        decimal GetTotal();

        ICollection<ShoppingCartItem> AllProducts();
    }
}

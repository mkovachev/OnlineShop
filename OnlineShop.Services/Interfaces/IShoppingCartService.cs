using OnlineShop.Data.Models;
using OnlineShop.Services.Models.ShoppingCartService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Services.Interfaces
{
    public interface IShoppingCartService //: ISingletonService
    {
        Task<Product> FindProductByIdAsync(int productId);

        void AddToCart(Product product, int amount);

        void RemoveProduct(Product product);

        void ClearCart();

        decimal GetTotal();

        List<ShoppingCartItem> AllProducts();
    }
}

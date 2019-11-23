using OnlineShop.Data;
using OnlineShop.Data.Models;
using OnlineShop.Services.Models.ProductService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductListingServiceModel>> AllAsync(int page = 1, int pageSize = DataConstants.PageSize);

        int TotalPages();

        Task<Product> ByIdAsync(int id);

        Task<List<ProductListingServiceModel>> SearchAsync(string search);
    }
}

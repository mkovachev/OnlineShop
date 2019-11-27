using OnlineShop.Data;
using OnlineShop.Data.Models;
using OnlineShop.Services.Common;
using OnlineShop.Services.Models.ProductService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Services.Interfaces
{
    public interface IProductService : ITransientService
    {
        Task<IEnumerable<ProductListingServiceModel>> AllAsync(int page = 1, int pageSize = DataConstants.PageSize);

        int TotalPages();

        Task<Product> ByIdAsync(int id);

        Task<IEnumerable<ProductListingServiceModel>> SearchAsync(string search);
    }
}

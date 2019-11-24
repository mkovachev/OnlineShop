using OnlineShop.Data;
using OnlineShop.Data.Models;
using OnlineShop.Services.Common;
using OnlineShop.Services.Models.ProductService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Services.Interfaces
{
    public interface ICategoryService : IService
    {
        Task<Category> ByIdAsync(int id);

        Task<IEnumerable<ProductListingServiceModel>> AllProductsInCategoryAsync(int categoryId, int page = 1, int pageSize = DataConstants.PageSize);

        int TotalPages();
    }
}

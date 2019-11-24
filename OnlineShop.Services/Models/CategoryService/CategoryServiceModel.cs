using OnlineShop.Common.Mapping;
using OnlineShop.Data.Models;
using OnlineShop.Services.Models.ProductService;
using System.Collections.Generic;

namespace OnlineShop.Services.Models.CategoryService
{
    public class CategoryServiceModel : IMapFrom<Category>
    {
        public List<ProductListingServiceModel> Products { get; set; }
    }
}

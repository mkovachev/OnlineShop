using OnlineShop.Services.Models.ProductService;
using System.Collections.Generic;

namespace OnlineShop.Services.Models.CategoryService
{
    public class CategoryServiceModel
    {
        public List<ProductListingServiceModel> Products { get; set; }
    }
}

using OnlineShop.Services.Models.ProductService;
using System.Collections.Generic;

namespace OnlineShop.Controllers.Models.CategoryViewModels
{
    public class CategoryViewModel
    {
        public IEnumerable<ProductListingServiceModel> Products { get; set; }

        public int Current { get; set; }

        public int Previous => this.Current == 1 ? 1 : this.Current - 1;

        public int TotalPages { get; set; }

        public int Next => this.Current == TotalPages ? this.TotalPages : Current + 1;

        public string Search { get; set; }

    }
}

using OnlineShop.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Services.Models.ProductService
{
    public class ProductDetailsServiceModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        [DataType(DataType.ImageUrl)]
        public List<Image> Images { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}

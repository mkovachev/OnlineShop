using OnlineShop.Data.Models;
using System.Collections.Generic;

namespace OnlineShop.Services.Admin.Models
{
    public class AdminCategoryServiceModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}

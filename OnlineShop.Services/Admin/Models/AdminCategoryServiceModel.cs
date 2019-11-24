using OnlineShop.Common.Mapping;
using OnlineShop.Data.Models;
using System;
using System.Collections.Generic;

namespace OnlineShop.Services.Admin.Models
{
    public class AdminCategoryServiceModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}

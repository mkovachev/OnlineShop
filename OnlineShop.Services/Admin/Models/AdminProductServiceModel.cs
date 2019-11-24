using OnlineShop.Common.Mapping;
using OnlineShop.Data.Models;
using System;
using System.Collections.Generic;
using Image = OnlineShop.Data.Models.Image;

namespace OnlineShop.Services.Admin.Models
{
    public class AdminProductServiceModel : IMapFrom<Product>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public decimal Price { get; set; }

        public string Thumbnail { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<Image> Images { get; set; } = new List<Image>();

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public int OrderDetailId { get; set; }

        public OrderDetail OrderDetail { get; set; }
    }
}

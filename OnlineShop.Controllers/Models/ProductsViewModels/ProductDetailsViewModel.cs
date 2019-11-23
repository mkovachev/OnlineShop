﻿using OnlineShop.Data.Models;
using System.Collections.Generic;

namespace OnlineShop.Controllers.Models.ProductsViewModels
{
    public class ProductDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public ICollection<Image> Images { get; set; } = new List<Image>();
    }
}

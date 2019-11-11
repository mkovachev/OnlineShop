﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Data.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DataValidations.CategoryNameMinLength)]
        [MaxLength(DataValidations.CategoryNameMaxLength)]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
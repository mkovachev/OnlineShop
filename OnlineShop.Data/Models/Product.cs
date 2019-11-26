using OnlineShop.Data.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Data.Models
{
    public class Product : IAuditable, IDeletable

    {
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.ProductTitleMinLength)]
        [MaxLength(DataConstants.ProductTitleMaxLength)]
        public string Title { get; set; }

        [MaxLength(DataConstants.ProductShortDescriptionMaxLength)]
        public string ShortDescription { get; set; }

        [MinLength(DataConstants.ProductDescriptionMinLength)]
        [MaxLength(DataConstants.ProductDescriptionMaxLength)]
        public string LongDescription { get; set; }

        [Range(0, 10000)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [MinLength(10)]
        [MaxLength(2000)]
        [DataType(DataType.ImageUrl)]
        public string Thumbnail { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<Image> Images { get; set; } = new List<Image>();

        public int CategoryId { get; set; }

        //public Category Category { get; set; }

        public int OrderDetailId { get; set; }

        public OrderDetail OrderDetail { get; set; }
    }
}
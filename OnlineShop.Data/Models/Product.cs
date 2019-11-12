using OnlineShop.Data.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Data.Models
{
    public class Product : IAuditable, IDeletable

    {
        public Guid Id { get; set; }

        [Required]
        [MinLength(DataValidations.ProductTitleMinLength)]
        [MaxLength(DataValidations.ProductTitleMaxLength)]
        public string Title { get; set; }

        [MaxLength(DataValidations.ProductShortDescriptionMaxLength)]
        public string ShortDescription { get; set; }

        [MinLength(DataValidations.ProductDescriptionMinLength)]
        [MaxLength(DataValidations.ProductDescriptionMaxLength)]
        public string Description { get; set; }

        [Range(0, 10000)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [MinLength(10)]
        [MaxLength(2000)]
        [DataType(DataType.ImageUrl)]
        public string Thumbnail { get; set; }

        public ICollection<Image> Images { get; set; } = new List<Image>();

        public string CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
using OnlineShop.Data.Contracts;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Data.Models
{
    public class Category: IAuditable, IDeletable
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.CategoryNameMinLength)]
        [MaxLength(DataConstants.CategoryNameMaxLength)]
        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
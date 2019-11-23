using OnlineShop.Data.Contracts;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Data.Models
{
    public class Image : IAuditable, IDeletable
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        [Required]
        [MaxLength(4)]
        public string FileExtension { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
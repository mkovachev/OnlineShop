using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Data.Models
{
    public class Image
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        [Required]
        [MaxLength(4)]
        public string FileExtension { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
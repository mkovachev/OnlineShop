using OnlineShop.Data.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Data.Models
{
    public class OrderDetail : IAuditable, IDeletable
    {
        public string Id { get; set; }

        [Range(0, 10000)]
        [DataType(DataType.Currency)]
        public decimal OrderTotal { get; set; }

        [Range(0, 10000)]
        [DataType(DataType.Currency)]
        public decimal ProductPrice { get; set; }

        public DateTime OrderPlaced { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<Product> Products = new List<Product>();

        public int OrderId { get; set; }

        public Order Order { get; set; }
    }
}
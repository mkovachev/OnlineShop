using OnlineShop.Data.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Data.Models
{
    public class OrderDetail : IAuditable, IDeletable
    {
        public ICollection<Product> Products = new List<Product>();
        public Guid Id { get; set; }

        [Range(0, 10000)]
        [DataType(DataType.Currency)]
        public decimal OrderTotal { get; set; }

        public DateTime OrderPlaced { get; set; }

        public string OrderId { get; set; }

        public virtual Order Order { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
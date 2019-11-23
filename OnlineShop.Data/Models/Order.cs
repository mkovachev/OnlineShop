using System.Collections.Generic;

namespace OnlineShop.Data.Models
{
    public class Order
    {
        public int Id { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

        public ICollection<ShippingDetail> ShippingDetails { get; set; } = new List<ShippingDetail>();

        public string UserId { get; set; }

        public User User { get; set; }
    }
}
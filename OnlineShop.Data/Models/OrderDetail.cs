using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Data.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }

        public int Amount { get; set; }

        [Range(0, 10000)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public int OrderId { get; set; }

        public virtual Order Order { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
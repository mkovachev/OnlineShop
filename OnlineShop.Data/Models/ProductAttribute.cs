using System.Collections.Generic;

namespace OnlineShop.Data.Models
{
    public class ProductAttribute
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<AttributeParam> AttributeParams { get; set; } = new List<AttributeParam>();

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
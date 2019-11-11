namespace OnlineShop.Data.Models
{
    public partial class AttributeParam
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ProductAttributeId { get; set; }

        public virtual ProductAttribute ProductAttribute { get; set; }
    }
}
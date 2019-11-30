using OnlineShop.Common.Mapping;

namespace OnlineShop.Services.Models.ShoppingCartService
{
    public class ShoppingCartServiceModel : IMapFrom<ShoppingCart>
    {
        public string Id { get; set; }
    }
}

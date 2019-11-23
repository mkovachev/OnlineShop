using OnlineShop.Services.Models.ShoppingCartService;

namespace OnlineShop.Controllers.Models.ShoppingCartViewModels
{
    public class ShoppingCartViewModel
    {
        public ShoppingCart ShoppingCart { get; set; }

        public decimal ShoppingCartTotal { get; set; }
    }
}

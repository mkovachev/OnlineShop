using System.Collections.Generic;

namespace OnlineShop.Services.Models.ShoppingCartService
{
    public class ShoppingCart
    {
        public string Id { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}

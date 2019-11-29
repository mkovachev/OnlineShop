using System;
using System.Collections.Generic;

namespace OnlineShop.Services.Models.ShoppingCartService
{
    public class ShoppingCart
    {
        public string Id { get; set; }

        public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; } = new List<ShoppingCartItem>();
    }
}
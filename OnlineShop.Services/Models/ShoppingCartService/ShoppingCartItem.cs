﻿using OnlineShop.Data.Models;

namespace OnlineShop.Services.Models.ShoppingCartService
{
    public class ShoppingCartItem
    {
        public string Id { get; set; }

        public int Quantity { get; set; }

        public Product Product { get; set; }

        public string ShoppingCartId { get; set; }
    }
}
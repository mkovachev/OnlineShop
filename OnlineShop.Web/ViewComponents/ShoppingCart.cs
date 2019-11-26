using Microsoft.AspNetCore.Mvc;
using OnlineShop.Controllers.Models.ShoppingCartViewModels;
using OnlineShop.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace OnlineShop.Web.ViewComponents
{
    public class ShoppingCart : ViewComponent
    {
        private readonly ShoppingCart shoppingCart;
        private readonly IShoppingCartService shoppingCartServices;

        public ShoppingCart(ShoppingCart shoppingCart, IShoppingCartService shoppingCartServices)
        {
            this.shoppingCart = shoppingCart ?? throw new ArgumentNullException(nameof(shoppingCart));
            this.shoppingCartServices = shoppingCartServices ?? throw new ArgumentNullException(nameof(shoppingCartServices));
        }

        public async Task<IViewComponentResult> InvokeAsync()
            => await Task.Run(() => View(new ShoppingCartViewModel
            {
                //ShoppingCart = this.shoppingCart, //TODO
                ShoppingCartTotal = this.shoppingCartServices.GetTotal()
            }));
    }
}

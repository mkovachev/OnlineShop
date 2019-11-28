using Microsoft.AspNetCore.Mvc;
using OnlineShop.Controllers.Models.ShoppingCartViewModels;
using OnlineShop.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace OnlineShop.Web.ViewComponents
{
    [ViewComponentAttribute]
    public class ShoppingCart : ViewComponent
    {
        private readonly Services.Models.ShoppingCartService.ShoppingCart shoppingCart;
        private readonly IShoppingCartService shoppingCartServices;

        public ShoppingCart(Services.Models.ShoppingCartService.ShoppingCart shoppingCart, IShoppingCartService shoppingCartServices)
        {
            this.shoppingCart = shoppingCart ?? throw new ArgumentNullException(nameof(shoppingCart));
            this.shoppingCartServices = shoppingCartServices ?? throw new ArgumentNullException(nameof(shoppingCartServices));
        }

        public async Task<IViewComponentResult> InvokeAsync()
            => await Task.Run(() => View(new ShoppingCartViewModel
            {
                ShoppingCart = this.shoppingCart,
                ShoppingCartTotal = this.shoppingCartServices.GetTotal()
            }));
    }
}

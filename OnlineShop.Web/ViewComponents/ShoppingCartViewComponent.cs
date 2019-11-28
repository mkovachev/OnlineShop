using Microsoft.AspNetCore.Mvc;
using OnlineShop.Controllers.Models.ShoppingCartViewModels;
using OnlineShop.Services.Interfaces;
using OnlineShop.Services.Models.ShoppingCartService;
using System;
using System.Threading.Tasks;

namespace OnlineShop.Web.ViewComponents
{
    [ViewComponent(Name = "ShoppingCart")]
    public class ShoppingCartViewComponent : ViewComponent
    {
        private readonly ShoppingCart shoppingCart;
        private readonly IShoppingCartService shoppingCartServices;

        public ShoppingCartViewComponent(ShoppingCart shoppingCart, IShoppingCartService shoppingCartServices)
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

using Microsoft.AspNetCore.Mvc;
using OnlineShop.Controllers.Models.ShoppingCartViewModels;
using OnlineShop.Services.Interfaces;
using OnlineShop.Services.Models.ShoppingCartService;
using System;
using System.Threading.Tasks;

namespace OnlineShop.Controllers.Implementations
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService shoppingCartServices;
        private readonly ShoppingCart shoppingCart;

        public ShoppingCartController(IShoppingCartService shoppingCartServices, ShoppingCart shoppingCart)
        {
            this.shoppingCartServices = shoppingCartServices ?? throw new ArgumentNullException(nameof(shoppingCartServices));
            this.shoppingCart = shoppingCart ?? throw new ArgumentNullException(nameof(shoppingCart));
        }

        public async Task<IActionResult> Index()
            => await Task.Run(() => View(new ShoppingCartViewModel
            {
                ShoppingCart = shoppingCart,
                ShoppingCartTotal = this.shoppingCartServices.GetTotal()
            }));

        public async Task<IActionResult> AddToCart(int id)
        {
            var shoppingCartItem = await this.shoppingCartServices.FindProductByIdAsync(id);

            if (shoppingCartItem == null)
            {
                return NotFound();
            }

            this.shoppingCartServices.AddToCart(shoppingCartItem, 1);

            this.TempData.Add(ControllerConstants.SuccessMessage, $"{shoppingCartItem.Title} successfully added to cart");

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var shoppingCartItem = await this.shoppingCartServices.FindProductByIdAsync(id);

            if (shoppingCartItem == null)
            {
                return NotFound();
            }

            this.shoppingCartServices.RemoveProduct(shoppingCartItem);

            TempData.Add(ControllerConstants.SuccessMessage, $"{shoppingCartItem.Title} amount updated successfully");

            return RedirectToAction("Index", nameof(shoppingCart));
        }
    }
}

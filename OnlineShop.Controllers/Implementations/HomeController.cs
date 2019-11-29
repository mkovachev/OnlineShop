using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Controllers.Models;
using OnlineShop.Controllers.Models.ProductsViewModels;
using OnlineShop.Data;
using OnlineShop.Services.Interfaces;
using OnlineShop.Services.Models.ShoppingCartService;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace OnlineShop.Controllers.Implementations
{
    public class HomeController : Controller
    {
        private readonly IProductService products;
        private readonly ShoppingCart shoppingCart;

        private const string sessionKey = "session";

        public HomeController(IProductService products, ShoppingCart shoppingCart)
        {
            this.products = products ?? throw new ArgumentNullException(nameof(products));
            this.shoppingCart = shoppingCart ?? throw new ArgumentNullException(nameof(shoppingCart));
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var sessionId = this.HttpContext.Session.GetString(sessionKey);

            if (sessionId == null)
            {
                sessionId = this.shoppingCart.Id;
                this.HttpContext.Session.SetString(sessionKey, sessionId);
            }

            return View(new ProductListingViewModel
            {
                Products = await this.products.AllAsync(page, DataConstants.PageSize),
                Current = page,
                TotalPages = (int)Math.Ceiling(this.products.TotalPages() / (double)DataConstants.PageSize)
            });
        }

      public async Task<IActionResult> Search(ProductListingViewModel model)
        {
            return View(new ProductListingViewModel
            {
                Search = model.Search,
                Products = await this.products.SearchAsync(model.Search)
            });
        }

        public async Task<IActionResult> About() => await Task.Run(() => View());

        public async Task<IActionResult> Contact() => await Task.Run(() => View());

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
            => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
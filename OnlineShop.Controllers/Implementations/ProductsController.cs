using Microsoft.AspNetCore.Mvc;
using OnlineShop.Controllers.Models.ProductsViewModels;
using OnlineShop.Services.Admin.Interfaces;
using System.Threading.Tasks;

namespace OnlineShop.Controllers.Implementations
{
    public class ProductsController : Controller
    {

        private readonly IAdminProductService products;

        public ProductsController(IAdminProductService products)
        {
            this.products = products;
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await products.FindByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return await Task.Run(() => View(new ProductDetailsViewModel
            {
                Id = product.Id,
                Title = product.Title,
                LongDescription = product.LongDescription,
                Images = product.Images
            }));

        }
    }
}

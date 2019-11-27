using Microsoft.AspNetCore.Mvc;
using OnlineShop.Controllers.Models.CategoryViewModels;
using OnlineShop.Data;
using OnlineShop.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace OnlineShop.Controllers.Implementations
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService categories;

        public CategoriesController(ICategoryService categories)
        {
            this.categories = categories ?? throw new ArgumentNullException(nameof(categories));
        }

        public async Task<IActionResult> Index(int id, int page = 1)
        {
            if (!int.TryParse(id.ToString(), out var n))
            {
                return NotFound();
            }

            return View(new CategoryViewModel
            {
                Products = await this.categories.AllProductsInCategoryAsync(id, page, DataConstants.PageSize),
                Current = page,
                TotalPages = (int)Math.Ceiling(this.categories.TotalPages() / (double)DataConstants.PageSize)
            });
        }
    }
}

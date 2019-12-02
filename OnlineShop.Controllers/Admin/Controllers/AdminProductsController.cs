using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShop.Controllers.Admin.Controllers.Abstract;
using OnlineShop.Controllers.Admin.Models.ProductAdminViewModels;
using OnlineShop.Controllers.Infrastructure;
using OnlineShop.Services.Admin.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Controllers.Admin.Controllers
{
    public class AdminProductsController : AdminController
    {
        private readonly IAdminProductService products;
        private readonly IAdminCategoryService categories;

        public AdminProductsController(IAdminProductService products, IAdminCategoryService categories)
        {
            this.products = products;
            this.categories = categories;
        }

        public async Task<IActionResult> CreateAsync()
            => View(new CreateEditProductViewModel
            {
                CreatedOn = DateTime.UtcNow,
                Categories = await this.GetCategoriesAsync()
            });

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateEditProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await this.GetCategoriesAsync();
                return View(model);
            }

            var product = this.products.ExistsByName(model.Title);

            if (!product)
            {
                await this.products.CreateAsync(
                    model.Title,
                    model.ShortDescription,
                    model.LongDescription,
                    model.Price,
                    model.Images,
                    model.Thumbnail,
                    model.CategoryId);
            }

            TempData.AddSuccessMessage($"Product {model.Title} created successfully!");

            return Redirect("/");
        }

        public async Task<IActionResult> EditAsync(int id)
        {
            var product = await this.products.FindByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(new CreateEditProductViewModel
            {
                Title = product.Title,
                ShortDescription = product.ShortDescription,
                LongDescription = product.LongDescription,
                Price = product.Price,
                Images = product.Images,
                Thumbnail = product.Thumbnail,
                CategoryId = product.CategoryId,
                Categories = await this.GetCategoriesAsync()
            });

        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(int id, CreateEditProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var product = this.products.ExistsById(id);
            var categories = await this.GetCategoriesAsync();

            if (categories == null || !product)
            {
                return NotFound();
            }

            await this.products.EditAsync(
                id,
                model.Title,
                model.ShortDescription,
                model.LongDescription,
                model.Price,
                model.Images,
                model.Thumbnail,
                model.CategoryId);

            TempData.AddSuccessMessage($"Product {model.Title} updated successfully!");

            return Redirect("/");
        }

        public async Task<IActionResult> Delete(int id) => await Task.Run(() => View(id));

        public async Task<IActionResult> DeleteProduct(int id)
        {
            await this.products.DeleteAsync(id);

            TempData.AddWarningMessage($"Product deleted successfully!");

            return Redirect("/");
        }

        private async Task<IEnumerable<SelectListItem>> GetCategoriesAsync()
        {
            var categories = await this.categories.AllAsync();

            var categoriesList = categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            })
            .ToList();

            return categoriesList;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using OnlineShop.Controllers.Admin.Models.Category;
using OnlineShop.Controllers.Infrastructure;
using OnlineShop.Services.Admin.Interfaces;
using OnlineShop.Services.Admin.Models;
using System;
using System.Threading.Tasks;

namespace OnlineShop.Controllers.Admin.Controllers
{
    public class CategoriesController : AdminController
    {
        private readonly IAdminCategoryService categories;

        public CategoriesController(IAdminCategoryService categories)
        {
            this.categories = categories ?? throw new ArgumentNullException(nameof(categories));
        }

        public async Task<IActionResult> Test() => await Task.Run(() => View());

        public async Task<IActionResult> Create() => await Task.Run(() => View());

        [HttpPost]
        public async Task<IActionResult> Create(CreateEditCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var category = this.categories.ExistsByName(model.Name);

            if (!category)
            {
                await this.categories.CreateAsync(model.Name);
            }

            TempData.AddSuccessMessage($"Category {model.Name} created successfully!");

            return Redirect("/");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var category = await this.categories.FindByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(new AdminCategoryServiceModel
            {
                Name = category.Name
            });

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CreateEditCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var category = this.categories.ExistsById(id);

            if (!category)
            {
                return NotFound();
            }

            await this.categories.EditAsync(id, model.Name);

            TempData.AddSuccessMessage($"Category {model.Name} updated successfully!");

            return Redirect("/");
        }

        public async Task<IActionResult> Delete() => await Task.Run(() => View());

        public async Task<IActionResult> Delete(int id)
        {
            await this.categories.DeleteAsync(id);

            TempData.AddWarningMessage($"Category deleted successfully!");

            return Redirect("/");
        }
    }
}

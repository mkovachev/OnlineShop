using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Controllers.Admin.Controllers.Abstract;
using OnlineShop.Controllers.Admin.Models.UserAdminViewModels;
using OnlineShop.Controllers.Infrastructure;
using OnlineShop.Data.Models;
using OnlineShop.Services.Admin.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Controllers.Admin.Controllers
{
    public class AdminUsersController : AdminController
    {
        private readonly IAdminUserService users;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;

        public AdminUsersController(IAdminUserService users, RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            this.users = users;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await this.users.AllAsync();
            var roles = await this.roleManager
                            .Roles
                            .Select(r => new SelectListItem
                            {
                                Text = r.Name,
                                Value = r.Name
                            })
                            .ToListAsync();

            return View(new AllUsersViewModel
            {
                Users = users,
                Roles = roles
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddtoRole(AddUserToRoleViewModel model)
        {
            var roleExists = await this.roleManager.RoleExistsAsync(model.Role);
            var user = await this.userManager.FindByIdAsync(model.UserId);

            if (user == null || !roleExists)
            {
                ModelState.AddModelError(string.Empty, "Invalid identity details.");
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }

            var userisInRole = await userManager.IsInRoleAsync(user, model.Role);

            if (userisInRole)
            {
                TempData.AddErrorMessage($"{user.UserName} already has role {model.Role}!");
                return RedirectToAction(nameof(Index));
            }
            else
            {
                await this.userManager.AddToRoleAsync(user, model.Role);

                TempData.AddSuccessMessage($"User {user.UserName} successfully added to role {model.Role}.");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShop.Services.Admin.Models;
using System.Collections.Generic;

namespace OnlineShop.Controllers.Admin.Models.UserAdminViewModels
{
    public class AllUsersViewModel
    {
        public IEnumerable<AdminUserServiceModel> Users { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}

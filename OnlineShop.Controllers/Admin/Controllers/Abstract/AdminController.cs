using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Controllers.Admin.Controllers.Abstract
{
    [Area("Admin")]
    [Authorize(Roles = ControllerConstants.AdministratorRole)]
    public abstract class AdminController : Controller
    {
    }
}

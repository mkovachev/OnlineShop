using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace OnlineShop.Controllers.Implementations
{
    public class BrandsController : Controller
    {
        public async Task<IActionResult> Index() => await Task.Run(() => View());
    }
}
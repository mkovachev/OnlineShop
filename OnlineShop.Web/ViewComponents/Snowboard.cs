using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Web.ViewComponents
{
    public class Snowboard : ViewComponent
    {
        private readonly OnlineShopDbContext db;

        public Snowboard(OnlineShopDbContext db) => this.db = db;

        public async Task<IViewComponentResult> InvokeAsync()
            => View(await this.db.Categories
                                   .Where(c => c.Name.Contains("Snowboard"))
                                   .OrderBy(c => c.Name)
                                   .ToListAsync());
    }
}

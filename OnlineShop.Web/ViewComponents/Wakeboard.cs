using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Web.ViewComponents
{
    public class Wakeboard : ViewComponent
    {
        private readonly OnlineShopDbContext db;

        public Wakeboard(OnlineShopDbContext db)
            => this.db = db ?? throw new ArgumentNullException(nameof(db));

        public async Task<IViewComponentResult> InvokeAsync()
          => View(await this.db.Categories
                                 .Where(c => c.Name.Contains("Wakeboard"))
                                 .OrderBy(c => c.Name)
                                 .ToListAsync());
    }
}

using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Web.ViewComponents
{
    public class Kitesurf : ViewComponent
    {
        private readonly OnlineShopDbContext db;

        public Kitesurf(OnlineShopDbContext db)
            => this.db = db ?? throw new ArgumentNullException(nameof(db));

        public async Task<IViewComponentResult> InvokeAsync()
          => View(await this.db.Categories
                                 .Where(c => c.Name.Contains("Kite"))
                                 .OrderBy(c => c.Name)
                                 .ToListAsync());

    }
}

using Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace OnlineShop.Web.ViewComponents
{
    public class Ski : ViewComponent
    {
        private readonly OnlineShopDbContext db;

        public Ski(OnlineShopDbContext db) => this.db = db ?? throw new ArgumentNullException(nameof(db));

        public IViewComponentResult Invoke()
            => View(this.db.Categories
                        .Where(c => c.Name.Contains("Ski"))
                        .OrderBy(p => p.Name));
    }
}

using Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace OnlineShop.Web.ViewComponents
{
    public class Wakeboard : ViewComponent
    {
        private readonly OnlineShopDbContext db;

        public Wakeboard(OnlineShopDbContext db)
            => this.db = db ?? throw new ArgumentNullException(nameof(db));

        public IViewComponentResult Invoke()
         => View(this.db.Categories
                    .Where(c => c.Name.Contains("Wakeboard"))
                    .OrderBy(c => c.Name));
    }
}

using Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace OnlineShop.Web.ViewComponents
{
    public class Snowboard : ViewComponent
    {
        private readonly OnlineShopDbContext db;

        public Snowboard(OnlineShopDbContext db) => this.db = db;

        public IViewComponentResult Invoke()
            => View(this.db.Categories
                        .Where(c => c.Name.Contains("Snowboard"))
                        .OrderBy(c => c.Name));

    }
}

using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Web.Infrastructure
{
    public static class MvcOptionsExtensions
    {
        public static MvcOptions AddAutoValidateAntiforgeryToken(this MvcOptions options)
        {
            options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
            return options;
        }
    }

}

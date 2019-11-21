using OnlineShop.Services.Admin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Services.Admin.Interfaces
{
    public interface IAdminUserService
    {
        Task<IEnumerable<AdminUserServiceModel>> AllAsync();
    }
}

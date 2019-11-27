using OnlineShop.Services.Admin.Models;
using OnlineShop.Services.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Services.Admin.Interfaces
{
    public interface IAdminUserService : ITransientService
    {
        Task<IEnumerable<AdminUserServiceModel>> AllAsync();
    }
}

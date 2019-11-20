using OnlineShop.Services.Admin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Services.Admin.Interfaces
{
    public interface IAdminCategoryService
    {
        Task<AdminCategoryServiceModel> FindByIdAsync(int id);

        Task<IEnumerable<AdminCategoryServiceModel>> AllAsync();

        Task CreateAsync(string name);

        Task EditAsync(int id, string name);

        Task DeleteAsync(int id);

        bool ExistsById(int id);

        bool ExistsByName(string name);
    }
}

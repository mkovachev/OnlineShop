using OnlineShop.Data.Models;
using OnlineShop.Services.Admin.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Services.Admin.Interfaces
{
    public interface IAdminProductService
    {

        Task CreateAsync(
            string title,
            string shortDescription,
            string longDescription,
            decimal price,
            List<Image> images,
            string thumbnail,
            int categoryId,
            int orderDetailId
            );

        Task EditAsync(
            int id,
            string title,
            string shortDescription,
            string description,
            decimal price,
            List<Image> images,
            string thumbnail,
            int categoryId,
            int orderDetailId
            );

        Task DeleteAsync(int id);
        Task<AdminProductServiceModel> FindByIdAsync(int id);

        Task<AdminProductServiceModel> DetailsAsync(int id);

        bool ExistsById(int id);

        bool ExistsByName(string title);
    }
}

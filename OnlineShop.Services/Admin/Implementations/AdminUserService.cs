using AutoMapper.QueryableExtensions;
using Data;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Services.Admin.Interfaces;
using OnlineShop.Services.Admin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Services.Admin.Implementations
{
    public class AdminUserService : IAdminUserService
    {
        private readonly OnlineShopDbContext db;

        public AdminUserService(OnlineShopDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<AdminUserServiceModel>> AllAsync()
            => await this.db
                       .Users
                       .ProjectTo<AdminUserServiceModel>(null)
                       .ToListAsync();
    }
}

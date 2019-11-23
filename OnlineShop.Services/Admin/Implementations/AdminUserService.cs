using AutoMapper;
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
        private readonly IMapper mapper;

        public AdminUserService(OnlineShopDbContext db, IMapper mapper)
        {
            this.db = db ?? throw new System.ArgumentNullException(nameof(db));
            this.mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<AdminUserServiceModel>> AllAsync()
            => await db
                       .Users
                       .ProjectTo<AdminUserServiceModel>(mapper.ConfigurationProvider)
                       .ToListAsync();
    }
}

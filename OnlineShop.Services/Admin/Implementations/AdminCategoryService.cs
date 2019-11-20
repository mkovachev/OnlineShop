using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data.Models;
using OnlineShop.Services.Admin.Interfaces;
using OnlineShop.Services.Admin.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Services.Admin.Implementations
{
    public class AdminCategoryService : IAdminCategoryService
    {
        private readonly OnlineShopDbContext db;
        private readonly IMapper mapper;

        public AdminCategoryService(OnlineShopDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
        }

        public async Task<int> CreateAsync(string name)
        {
            var category = new Category
            {
                Name = name
            };

            this.db.Add(category);

            await this.db.SaveChangesAsync();

            return category.Id;
        }

        public async Task<IEnumerable<AdminCategoryServiceModel>> AllAsync()
            => await this.db
                .Categories
                .OrderBy(c => c.Name)
                .ProjectTo<AdminCategoryServiceModel>(this.mapper.ConfigurationProvider)
                .ToListAsync();

        public async Task<AdminCategoryServiceModel> FindByIdAsync(int id)
        => await this.db
                 .Categories
                 .Where(c => c.Id == id)
                 .ProjectTo<AdminCategoryServiceModel>(this.mapper.ConfigurationProvider)
                 .FirstOrDefaultAsync();

        public async Task EditAsync(int id, string name)
        {
            var category = await this.db.Categories.FindAsync(id);

            if (category == null)
            {
                return;
            }

            category.Name = name;

            await this.db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await this.db.Categories.FindAsync(id);

            if (category == null)
            {
                return;
            }

            this.db.Categories.Remove(category);

            await this.db.SaveChangesAsync();
        }

        public bool ExistsById(int id)
        {
            return this.db.Categories.Any(c => c.Id == id);
        }

        public bool ExistsByName(string name)
        {
            return this.db.Categories.Any(c => c.Name == name);
        }
    }
}

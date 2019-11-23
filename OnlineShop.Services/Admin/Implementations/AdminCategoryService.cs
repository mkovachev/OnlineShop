using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data.Models;
using OnlineShop.Services.Admin.Interfaces;
using OnlineShop.Services.Admin.Models;
using OnlineShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Services.Admin.Implementations
{
    public class AdminCategoryService : IAdminCategoryService
    {
        private readonly OnlineShopDbContext db;
        private readonly IMapper mapper;
        private readonly IDateTimeProvider dateTimeProvider;

        public AdminCategoryService(OnlineShopDbContext db, IMapper mapper, IDateTimeProvider dateTimeProvider)
        {
            this.db = db ?? throw new System.ArgumentNullException(nameof(db));
            this.mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
            this.dateTimeProvider = dateTimeProvider ?? throw new System.ArgumentNullException(nameof(dateTimeProvider));
        }

        public async Task<int> CreateAsync(string name)
        {
            Category category = new Category
            {
                Name = name,
                CreatedOn = this.dateTimeProvider.UtcNow()
            };

            db.Add(category);

            await db.SaveChangesAsync();

            return category.Id;
        }

        public async Task EditAsync(int id, string name)
        {
            Category category = await db.Categories.FindAsync(id);

            if (category == null)
            {
                return;
            }

            category.Name = name;
            category.ModifiedOn = this.dateTimeProvider.UtcNow();

            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Category category = await db.Categories.FindAsync(id);

            if (category == null)
            {
                return;
            }

            category.DeletedOn = this.dateTimeProvider.UtcNow();
            category.IsDeleted = true;
            //db.Categories.Remove(category);

            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<AdminCategoryServiceModel>> AllAsync()
          => await db
              .Categories
              .OrderBy(c => c.Name)
              .ProjectTo<AdminCategoryServiceModel>(this.mapper.ConfigurationProvider)
              .ToListAsync();

        public async Task<AdminCategoryServiceModel> FindByIdAsync(int id)
        => await db
                 .Categories
                 .Where(c => c.Id == id)
                 .ProjectTo<AdminCategoryServiceModel>(this.mapper.ConfigurationProvider)
                 .FirstOrDefaultAsync();

        public bool ExistsById(int id) => db.Categories.Any(c => c.Id == id);

        public bool ExistsByName(string name) => db.Categories.Any(c => c.Name == name);


    }
}

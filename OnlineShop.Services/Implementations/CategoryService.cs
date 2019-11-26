using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Data.Models;
using OnlineShop.Services.Interfaces;
using OnlineShop.Services.Models.CategoryService;
using OnlineShop.Services.Models.ProductService;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly OnlineShopDbContext db;
        private readonly IMapper mapper;

        public CategoryService(OnlineShopDbContext db, IMapper mapper)
        {
            this.db = db ?? throw new System.ArgumentNullException(nameof(db));
            this.mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<ProductListingServiceModel>> AllProductsInCategoryAsync(int categoryId, int page = 1, int pageSize = DataConstants.PageSize)
            => await this.db
                    .Products
                    .Where(p => p.CategoryId == categoryId)
                    .OrderBy(p => p.Title)
                    .ProjectTo<ProductListingServiceModel>(this.mapper.ConfigurationProvider)
                    .ToListAsync();

        public async Task<CategoryServiceModel> AllInCategoryAsync(int id, int page = 1, int pageSize = DataConstants.PageSize)
            => await this.db
                        .Categories
                        .Where(c => c.Id == id)
                        .Select(c => new CategoryServiceModel
                        {
                            Products = c.Products.Select(p => new ProductListingServiceModel
                            {
                                Title = p.Title,
                                ShortDescription = p.ShortDescription,
                                Thumbnail = p.Thumbnail,
                                Price = p.Price
                            })
                        })
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .ProjectTo<CategoryServiceModel>(this.mapper.ConfigurationProvider)
                        .FirstOrDefaultAsync();

        public async Task<Category> ByIdAsync(int id) => await this.db.Categories.FindAsync(id);
        public int TotalPages() => this.db.Categories.Count();
    }
}

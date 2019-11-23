using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Data.Models;
using OnlineShop.Services.Interfaces;
using OnlineShop.Services.Models.ProductService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly OnlineShopDbContext db;
        private readonly IMapper mapper;

        public ProductService(OnlineShopDbContext db, IMapper mapper)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<ProductListingServiceModel>> AllAsync(int page = 1, int pageSize = DataConstants.PageSize)
        {
            return await this.db
                        .Products
                        .OrderByDescending(p => p.CreatedOn)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .ProjectTo<ProductListingServiceModel>(this.mapper.ConfigurationProvider)
                        .ToListAsync();
        }

        public async Task<Product> ByIdAsync(int id) => await this.db.Products.FindAsync(id);

        public async Task<List<ProductListingServiceModel>> SearchAsync(string search)
        {
            search = search ?? string.Empty;

            return await this.db
                        .Products
                        .OrderByDescending(p => p.CreatedOn)
                        .Where(p => p.Title.ToLower().Contains(search.ToLower()))
                        .ProjectTo<ProductListingServiceModel>(this.mapper.ConfigurationProvider)
                        .ToListAsync();
        }
        public int TotalPages() => this.db.Products.Count();
    }
}

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
    public class AdminProductService : IAdminProductService
    {
        private readonly OnlineShopDbContext db;
        private readonly IMapper mapper;
        private readonly IDateTimeProvider dateTimeProvider;

        public AdminProductService(OnlineShopDbContext db, IMapper mapper, IDateTimeProvider dateTimeProvider, IAdminCategoryService adminCategoryService)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.dateTimeProvider = dateTimeProvider ?? throw new ArgumentNullException(nameof(dateTimeProvider));
        }


        public async Task CreateAsync(string title, string shortDescription, string longDescription, decimal price, List<Image> images, string thumbnail, int categoryId, int orderDetailId)
        {
            var product = new Product
            {
                Title = title,
                ShortDescription = shortDescription,
                LongDescription = longDescription,
                Price = price,
                Images = images,
                Thumbnail = thumbnail,
                CreatedOn = this.dateTimeProvider.UtcNow(),
                CategoryId = categoryId,
                OrderDetailId = orderDetailId
            };

            this.db.Products.Add(product);

            await this.db.SaveChangesAsync();
        }

        public async Task EditAsync(int id, string title, string shortDescription, string longDescription, decimal price, List<Image> images, string thumbnail, int categoryId, int orderDetailId)
        {
            var product = await this.db.Products.FindAsync(id);

            if (product == null)
            {
                return;
            }
            product.Title = title;
            product.ShortDescription = shortDescription;
            product.LongDescription = longDescription;
            product.Price = price;
            product.Images = images;
            product.Thumbnail = thumbnail;
            product.ModifiedOn = this.dateTimeProvider.UtcNow();
            product.CategoryId = categoryId;
            product.OrderDetailId = orderDetailId;

            await this.db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await this.db.Products.FindAsync(id);

            if (product == null)
            {
                return;
            }

            product.DeletedOn = this.dateTimeProvider.UtcNow();
            product.IsDeleted = true;
            //this.db.Products.Remove(product);

            await this.db.SaveChangesAsync();
        }

        public async Task<AdminProductServiceModel> FindByIdAsync(int id)
            => await this.db
                            .Products
                            .Where(p => p.Id == id)
                            .ProjectTo<AdminProductServiceModel>(this.mapper.ConfigurationProvider)
                            .FirstOrDefaultAsync();

        public bool ExistsById(int id)
        {
            return this.db.Products.Any(c => c.Id == id);
        }

        public bool ExistsByName(string title)
            => this.db.Products.Any(c => c.Title == title);

        public async Task<AdminProductServiceModel> DetailsAsync(int id)
            => await this.db
                    .Products
                    .Where(p => p.Id == id)
                    .ProjectTo<AdminProductServiceModel>(this.mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync();
    }
}

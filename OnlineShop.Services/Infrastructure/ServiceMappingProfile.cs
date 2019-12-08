using AutoMapper;
using OnlineShop.Data.Models;
using OnlineShop.Services.Admin.Models;
using OnlineShop.Services.Models.CategoryService;
using OnlineShop.Services.Models.ProductService;

namespace OnlineShop.Services.Infrastructure
{
    public class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile()
        {
            CreateMap<Product, ProductListingServiceModel>();
            CreateMap<Product, ProductDetailsServiceModel>();

            CreateMap<Category, CategoryServiceModel>();

            // Admin area
            CreateMap<Category, AdminCategoryServiceModel>();
            CreateMap<Product, AdminProductServiceModel>();
            CreateMap<User, AdminUserServiceModel>();
        }
    }
}

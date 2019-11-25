using AutoMapper;
using OnlineShop.Data.Models;
using OnlineShop.Services.Models.CategoryService;
using OnlineShop.Services.Models.ProductService;

namespace OnlineShop.Services.Infrastructure
{
    public class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile()
        {
            this.
                CreateMap<Product, ProductListingServiceModel>();
                CreateMap<Product, ProductDetailsServiceModel>();
                CreateMap<Category, CategoryServiceModel>();
        }
    }
}

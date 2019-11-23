using AutoMapper;
using OnlineShop.Data.Models;
using OnlineShop.Services.Admin.Models;
using OnlineShop.Services.Models;
using OnlineShop.Services.Models.ProductService;
using OnlineShop.Services.Models.ShoppingCartService;

namespace OnlineShop.Services.Infrastructure
{
    public class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile()
        {
            // Admin area
            CreateMap<Category, AdminCategoryServiceModel>();
            CreateMap<Product, AdminProductServiceModel>();
            CreateMap<User, AdminUserServiceModel>();


            CreateMap<Product, ProductDetailsServiceModel>();
            CreateMap<Product, ProductListingServiceModel>();

           // CreateMap<ShoppingCart, ShoppingCart>();
            CreateMap<ShoppingCart, ShoppingCartItem>();
            CreateMap<ShoppingCart, ShoppingCartServiceModel>();


            //CreateMap<DateTimeProvider, DateTimeProvider>();

        }
    }
}
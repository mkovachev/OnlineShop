using AutoMapper;
using OnlineShop.Controllers.Models.CategoryViewModels;
using OnlineShop.Controllers.Models.ProductsViewModels;
using OnlineShop.Services.Models.ProductService;

namespace OnlineShop.Controllers.Infrastructure
{
    public class ControllerMappingProfile : Profile
    {
        public ControllerMappingProfile()
        {

            this.CreateMap<ProductListingServiceModel, CategoryViewModel>();
                 CreateMap<ProductListingServiceModel, ProductListingViewModel>();
        }

    }
}

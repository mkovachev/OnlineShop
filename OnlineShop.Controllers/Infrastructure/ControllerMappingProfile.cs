using AutoMapper;

namespace OnlineShop.Controllers.Infrastructure
{
    public class ControllerMappingProfile : Profile
    {
        public ControllerMappingProfile()
        {
            CreateMap<AdminCategoryDetailsServiceModel, CategoryFormModel>();
        }
    }
}

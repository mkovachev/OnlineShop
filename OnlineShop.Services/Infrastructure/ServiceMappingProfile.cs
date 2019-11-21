using AutoMapper;
using OnlineShop.Data.Models;
using OnlineShop.Services.Admin.Models;

namespace OnlineShop.Services.Infrastructure
{
    public class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile()
        {
            this.CreateMap<Category, AdminCategoryServiceModel>();
            //.ForMember(a => a.Name, opt => opt.MapFrom(a => a.Name));


        }
    }
}

using AutoMapper;
using OnlineShop.Common.Mapping;
using OnlineShop.Data.Models;

namespace OnlineShop.Services.Models.ProductService
{
    public class ProductListingServiceModel : IMapFrom<Product>, IMapTo<Product>, IMapExplicitly
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public string ShortDescription { get; set; }

        public string Thumbnail { get; set; }

        public void RegisterMappings(IProfileExpression profile)
        {
            profile.CreateMap<Product, ProductListingServiceModel>()
                .ForMember(p => p.Title, cfg => cfg.MapFrom(p => p.Title));
        }
    }
}

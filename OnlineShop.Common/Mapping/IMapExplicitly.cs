using AutoMapper;

namespace OnlineShop.Common.Mapping
{
    public interface IMapExplicitly
    {
        public void RegisterMappings(IProfileExpression profile);
    }
}

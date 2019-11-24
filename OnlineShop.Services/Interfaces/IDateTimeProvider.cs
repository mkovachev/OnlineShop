using OnlineShop.Services.Common;
using System;

namespace OnlineShop.Services.Interfaces
{
    public interface IDateTimeProvider : ISingletonService
    {
        DateTime UtcNow();
    }
}

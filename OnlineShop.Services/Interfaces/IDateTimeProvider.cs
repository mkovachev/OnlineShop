using System;

namespace OnlineShop.Services.Interfaces
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow();
    }
}

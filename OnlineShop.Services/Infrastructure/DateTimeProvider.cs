using OnlineShop.Services.Interfaces;
using System;

namespace OnlineShop.Services.Infrastructure
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow() => DateTime.UtcNow;
    }
}

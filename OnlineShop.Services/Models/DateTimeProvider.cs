using OnlineShop.Services.Interfaces;
using System;

namespace OnlineShop.Services.Models
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow() => DateTime.UtcNow;
    }
}

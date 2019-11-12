using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using OnlineShop.Data.Contracts;

namespace OnlineShop.Data.Models
{
    public class User : IdentityUser, IAuditable
    {
        public ICollection<Order> Orders { get; set; } = new List<Order>();

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
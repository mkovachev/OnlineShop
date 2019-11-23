using System;

namespace OnlineShop.Services.Admin.Models
{
    public class AdminUserServiceModel
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public DateTime? ModifiedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}

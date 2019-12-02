using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Controllers.Admin.Models.AdminUserViewModels
{
    public class AddUserToRoleViewModel
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string Role { get; set; }
    }
}

using OnlineShop.Data;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Controllers.Admin.Models.CategoryAdminViewModels
{
    public class CreateEditCategoryViewModel
    {
        [Required]
        [MinLength(DataConstants.CategoryNameMinLength)]
        [MaxLength(DataConstants.CategoryNameMaxLength)]
        public string Name { get; set; }

    }
}

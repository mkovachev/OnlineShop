using OnlineShop.Data;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Controllers.Admin.Models.Category
{
    public class CreateEditCategoryViewModel
    {
        [Required]
        [MinLength(DataConstants.CategoryNameMinLength)]
        [MaxLength(DataConstants.CategoryNameMaxLength)]
        public string Name { get; set; }

    }
}

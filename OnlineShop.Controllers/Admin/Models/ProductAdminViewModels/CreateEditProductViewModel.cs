using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShop.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Controllers.Admin.Models.ProductAdminViewModels
{
    public class CreateEditProductViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public decimal Price { get; set; }

        public string Thumbnail { get; set; }

        public DateTime CreatedOn { get; set; }

        public ICollection<Image> Images { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}

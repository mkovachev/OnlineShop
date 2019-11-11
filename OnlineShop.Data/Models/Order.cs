using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Data.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Display(Name = "First name")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [Display(Name = "Postal code")]
        [StringLength(10, MinimumLength = 4)]
        public string PostalCode { get; set; }

        [StringLength(10)]
        public string City { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public decimal OrderTotal { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderPlaced { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
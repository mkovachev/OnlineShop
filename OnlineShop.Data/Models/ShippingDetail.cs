using OnlineShop.Data.Contracts;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Data.Models
{
    public class ShippingDetail : IAuditable, IDeletable
    {
        public int Id { get; set; }
        public User Recipient { get; set; }

        [Required]
        [Display(Name = "First name")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Postal code")]
        [StringLength(10, MinimumLength = 4)]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(10)]
        public string City { get; set; }

        [Required]
        [StringLength(50)]
        public string Country { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        public DateTime? EstimatedDeliveryDate { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Data.Contracts
{
    internal interface IAuditable
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.mm.yyyy}", ApplyFormatInEditMode = true)]
        DateTime CreatedOn { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.mm.yyyy}", ApplyFormatInEditMode = true)]
        DateTime? ModifiedOn { get; set; }
    }
}
using Contracts.Attributes;
using Domain.Models.Parameters.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Parameters
{
    public class AccountQueryParameters : QueryStringParametersBase
    {
        public new string OrderBy { get; set; } = "DateCreated";
        [DataType(DataType.Date)]
        [Display(Name = "Даты создания заканчивая до этой даты")]
        public DateTime MaxDateCreated { get; set; } = DateTime.MaxValue;

        [DataType(DataType.Date)]
        [Display(Name = "Даты создания начиная с этой даты")]
        [DateOfBirthRange(nameof(MaxDateCreated))]
        public DateTime MinDateCreated { get; set; } = DateTime.MinValue;
    }
}

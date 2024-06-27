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
    public class OwnerQueryParameters : QueryStringParametersBase
    {
        [DataType(DataType.Date)]
        [Display(Name = "Даты рождения заканчивая до этой даты")]
        public DateTime MaxDateOfBirth { get; set; } = DateTime.MaxValue;

        [DataType(DataType.Date)]
        [Display(Name = "Даты рождения начиная с этой даты")]
        [DateOfBirthRange(nameof(MaxDateOfBirth))]
        public DateTime MinDateOfBirth { get; set; } = DateTime.MinValue;

        public string Name { get; set; } = "";

        public new string OrderBy { get; set; } = "name";
    }
}

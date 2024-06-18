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
        public DateTime MaxYearOfBirth { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        [Display(Name = "Даты рождения начиная с этой даты")]
        [DateOfBirthRange(nameof(MaxYearOfBirth))]
        public DateTime MinYearOfBirth { get; set; } = DateTime.MinValue;

        public string Name { get; set; }
    }
}

using Contracts.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DataTransferObjects
{
    public class AccountForCreationDto
    {
        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime DateCreated { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(1)]
        [RegularExpression(@"^\S+$")]
        public AccountTypeDto AccountType { get; set; }
    }
}

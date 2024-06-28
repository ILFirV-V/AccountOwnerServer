using Contracts.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Contracts.DataTransferObjects
{
    public class AccountForCreationDto
    {
        [Required]
        [MaxLength(50)]
        [MinLength(1)]
        [RegularExpression(@"^\S+$")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [EnumDataType(typeof(AccountTypeDto))]
        public AccountTypeDto AccountType { get; set; }
    }
}

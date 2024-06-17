using Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DataTransferObjects
{
    public class AccountDto
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public AccountTypeDto AccountType { get; set; }
    }
}

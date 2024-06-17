using Contracts.Enums;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Extensions
{
    public static class AccountTypeExtensions
    {
        public static AccountType FromSrcToDst(this AccountTypeDto dtoType)
        {
            switch (dtoType)
            {
                case AccountTypeDto.Domestic:
                    return AccountType.Domestic;
                case AccountTypeDto.Savings:
                    return AccountType.Savings;
                case AccountTypeDto.Foreign:
                    return AccountType.Foreign;
                default:
                    throw new ArgumentOutOfRangeException("AccountTypeDto", dtoType, "Unknown AccountTypeDto value");
            }
        }

        public static AccountTypeDto FromSrcToDst(this AccountType type)
        {
            switch (type)
            {
                case AccountType.Domestic:
                    return AccountTypeDto.Domestic;
                case AccountType.Savings:
                    return AccountTypeDto.Savings;
                case AccountType.Foreign:
                    return AccountTypeDto.Foreign;
                default:
                    throw new ArgumentOutOfRangeException("AccountType", type, "Unknown AccountType value");
            }
        }
    }
}

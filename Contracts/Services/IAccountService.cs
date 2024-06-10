using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services
{
    public interface IAccountService
    {
        public Task<AccountDto?> GetAccountsByOwnerId(Guid ownerId);

        public Task<AccountDto?> GetAccountForOwner(Guid ownerId, Guid id);
    }
}

using AutoMapper;
using Contracts.Logger;
using Contracts.Repository;
using Contracts.Services;
using Entities.DataTransferObjects;
using Entities.DbModels;
using Entities.Exceptions;
using Entities.Extensions;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public sealed class AccountService : IAccountService
    {
        private readonly ILoggerManager logger;
        private readonly IRepositoryWrapper repository;
        private readonly IMapper mapper;

        public AccountService(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            this.logger = logger;
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<AccountDto?> GetAccountsByOwnerId(Guid ownerId)
        {
            var accountsDb = await repository.Account.GetAllByOwnerIdAsync(ownerId);
            if (accountsDb is null)
            {
                logger.LogError($"Accounts with owner id: {ownerId}, hasn't been found in db.");
                throw new NotFoundException($"Accounts with owner id {ownerId} not found");
            }
            logger.LogInfo($"Returned accounts with owner id: {ownerId}");
            var accounts = mapper.Map<AccountDto>(accountsDb);
            return accounts;
        }

        public async Task<AccountDto?> GetAccountForOwner(Guid ownerId, Guid id)
        {
            var accountDb = await repository.Account.GetAccountByOwner(ownerId, id);

            if (accountDb.IsObjectNull() || accountDb.IsEmptyObject())
            {
                logger.LogError($"Account with id: {id}, hasn't been found in db.");
                throw new NotFoundException($"Accounts with owner id {ownerId} not found");
            }
            logger.LogInfo($"Returned accounts with owner id: {ownerId}");
            var account = mapper.Map<AccountDto>(accountDb);
            return account;
        }
    }
}
using AutoMapper;
using Contracts.DataTransferObjects;
using Domain.DbModels;
using Domain.Exceptions;
using Domain.Extensions;
using Domain.Models;
using Domain.Models.Parameters.Base;
using Domain.Repository;
using Logging.Abstractions;
using Services.Abstractions;

namespace Services
{
    internal sealed class AccountService : IAccountService
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

        public async Task<IEnumerable<AccountDto>> GetAccountsByOwnerId(Guid ownerId, QueryStringParametersBase accountParameters, CancellationToken cancellationToken)
        {
            var parameters = mapper.Map<GetItemsQuery>(accountParameters);
            var accountsDb = await repository.Account.GetAllByOwnerIdAsync(ownerId, parameters, cancellationToken);
            if (accountsDb is null)
            {
                logger.LogError($"Accounts with owner id: {ownerId}, hasn't been found in db.");
                throw new NotFoundException($"Accounts with owner id {ownerId} not found");
            }
            logger.LogInfo($"Returned accounts with owner id: {ownerId}");

            var accounts = mapper.Map<IEnumerable<AccountDto>>(accountsDb);
            var pagedItems = new PagedList<AccountDto>(accounts, parameters.PageNumber, parameters.PageSize);

            return pagedItems;
        }

        public async Task<AccountDto?> GetAccountForOwner(Guid ownerId, Guid id, CancellationToken cancellationToken)
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

        public async Task<AccountDto> CreateAsync(Guid ownerId, AccountForCreationDto accountForCreationDto, CancellationToken cancellationToken = default)
        {
            var owner = await repository.Owner.GetOwnerByIdAsync(ownerId, cancellationToken);
            if (owner is null)
            {
                throw new NullReferenceException();
            }
            var account = mapper.Map<Account>(accountForCreationDto);
            account = account with
            {
                OwnerId = ownerId,
            };
            var accountDb = mapper.Map<AccountDbModel>(account);
            repository.Account.Create(accountDb);
            await repository.SaveAsync(cancellationToken);

            var accountDto = mapper.Map<AccountDto>(accountDb);
            return accountDto;
        }

        public async Task DeleteAsync(Guid ownerId, Guid accountId, CancellationToken cancellationToken = default)
        {
            var owner = await repository.Owner.GetOwnerByIdAsync(ownerId, cancellationToken);
            if (owner is null)
            {
                throw new NullReferenceException();
            }
            var account = await repository.Account.GetAccountByOwner(ownerId, accountId, cancellationToken);
            if (account is null)
            {
                throw new NullReferenceException();
            }
            if (account.OwnerId != owner.Id)
            {
                throw new AccountDoesNotBelongToOwnerException(owner.Id, account.Id);
            }
            repository.Account.Delete(account);
            await repository.SaveAsync(cancellationToken);
        }
    }
}
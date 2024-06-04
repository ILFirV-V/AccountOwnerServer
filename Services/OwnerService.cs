using AutoMapper;
using Contracts.Logger;
using Contracts.Repository;
using Contracts.Services;
using Entities.DataTransferObjects;
using Entities.DbModels;
using Entities.Exceptions;

namespace Services
{
    public sealed class OwnerService : IOwnerService
    {
        private readonly ILoggerManager logger;
        private readonly IRepositoryWrapper repository;
        private readonly IMapper mapper;

        public OwnerService(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            this.logger = logger;
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<OwnerDto>> GetAllOwners()
        {
            var ownersDb = await repository.Owner.GetAllOwnersAsync();
            logger.LogInfo($"Returned all owners from database.");
            var owners = mapper.Map<IEnumerable<OwnerDto>>(ownersDb);
            return owners;
        }

        public async Task<OwnerDto?> GetOwnerById(Guid id)
        {
            var ownerDb = await repository.Owner.GetOwnerByIdAsync(id);
            if (ownerDb is null)
            {
                logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                throw new NotFoundException($"Owner with ID {id} not found");
            }
            logger.LogInfo($"Returned owner with id: {id}");
            var ownerResult = mapper.Map<OwnerDto>(ownerDb);
            return ownerResult;
        }

        public async Task<OwnerDto?> GetOwnerWithDetails(Guid id)
        {
            var ownerDb = await repository.Owner.GetOwnerWithDetailsAsync(id);

            if (ownerDb is null)
            {
                logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                throw new NotFoundException($"Owner with ID {id} not found");
            }
            logger.LogInfo($"Returned owner with details for id: {id}");

            var ownerResult = mapper.Map<OwnerDto>(ownerDb);
            return ownerResult;
        }

        public async Task<OwnerDto?> CreateOwner(OwnerForCreationDto owner)
        {
            if (owner is null)
            {
                logger.LogError("Owner object sent from client is null.");
                throw new ArgumentNullException("Owner object is null");
            }

            var ownerEntity = mapper.Map<OwnerDbModel>(owner);

            repository.Owner.Create(ownerEntity);
            await repository.SaveAsync();

            var createdOwner = mapper.Map<OwnerDto>(ownerEntity);

            return createdOwner;
        }

        public async Task UpdateOwner(Guid id, OwnerForUpdateDto owner)
        {
            if (owner is null)
            {
                logger.LogError("Owner object sent from client is null.");
                throw new ArgumentNullException("Owner object is null");
            }

            var ownerEntity = await repository.Owner.GetOwnerByIdAsync(id);
            if (ownerEntity is null)
            {
                logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                throw new NotFoundException($"Owner with ID {id} not found");
            }

            mapper.Map(owner, ownerEntity);

            repository.Owner.Update(ownerEntity);
            await repository.SaveAsync();
        }

        public async Task DeleteOwner(Guid id)
        {
            var ownerDb = await repository.Owner.GetOwnerByIdAsync(id);
            if (ownerDb is null)
            {
                logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                throw new NotFoundException($"Owner with ID {id} not found");
            }
            var accounts = await repository.Account.AccountsByOwnerAsync(id);
            if (accounts.Any())
            {
                logger.LogError($"Cannot delete owner with id: {id}. It has related accounts. Delete those accounts first");
                throw new OwnerWithAccountsException("Cannot delete owner. It has related accounts. Delete those accounts first");
            }
            repository.Owner.Delete(ownerDb);
            await repository.SaveAsync();
        }
    }
}
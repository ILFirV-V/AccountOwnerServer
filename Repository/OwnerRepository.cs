using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Repository;
using Entities;
using Entities.DbModels;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public sealed class OwnerRepository : RepositoryBase<OwnerDbModel>, IOwnerRepositoryAsync
    {
        public OwnerRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<OwnerDbModel>> GetAllOwnersAsync(CancellationToken cancellationToken = default)
        {
            return await FindAll()
               .OrderBy(ow => ow.Name)
               .ToListAsync(cancellationToken);
        }

        public Task<OwnerDbModel?> GetOwnerByIdAsync(Guid ownerId, CancellationToken cancellationToken = default)
        {
            return FindByCondition(owner => owner.Id.Equals(ownerId))
                .FirstOrDefaultAsync(cancellationToken);
        }

        public Task<OwnerDbModel?> GetOwnerWithDetailsAsync(Guid ownerId, CancellationToken cancellationToken = default)
        {
            return FindByCondition(owner => owner.Id.Equals(ownerId))
                .Include(ac => ac.Accounts)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
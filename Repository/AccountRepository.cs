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
    public sealed class AccountRepository : RepositoryBase<AccountDbModel>, IAccountRepositoryAsync
    {
        public AccountRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<AccountDbModel>> GetAllByOwnerIdAsync(Guid ownerId, CancellationToken cancellationToken = default)
        {
            return await FindByCondition(a => a.OwnerId.Equals(ownerId)).ToListAsync(cancellationToken);
        }

        public async Task<AccountDbModel?> GetAccountByOwner(Guid ownerId, Guid id, CancellationToken cancellationToken = default)
        {
            return await FindByCondition(a => a.OwnerId.Equals(ownerId) && a.Id.Equals(id)).SingleOrDefaultAsync(cancellationToken);
        }
    }
}
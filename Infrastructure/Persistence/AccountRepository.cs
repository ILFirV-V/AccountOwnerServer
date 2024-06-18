using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DbModels;
using Domain.Models;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    internal sealed class AccountRepository : RepositoryBase<AccountDbModel>, IAccountRepositoryAsync
    {
        public AccountRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<AccountDbModel>> GetAllByOwnerIdAsync(Guid ownerId, GetItemsQuery itemsQuery, CancellationToken cancellationToken = default)
        {
            return await FindByCondition(a => a.OwnerId.Equals(ownerId))
                .Skip((itemsQuery.PageNumber - 1) * itemsQuery.PageSize)
                .Take(itemsQuery.PageSize)
                .ToListAsync(cancellationToken);
        }

        public async Task<bool> ExistsAny(Guid ownerId, CancellationToken cancellationToken = default)
        {
            return await FindByCondition(a => a.OwnerId.Equals(ownerId)).AnyAsync(cancellationToken);
        }

        public async Task<AccountDbModel?> GetAccountByOwner(Guid ownerId, Guid id, CancellationToken cancellationToken = default)
        {
            return await FindByCondition(a => a.OwnerId.Equals(ownerId) && a.Id.Equals(id)).SingleOrDefaultAsync(cancellationToken);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Repository;
using Entities;
using Entities.DbModels;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public sealed class AccountRepository : RepositoryBase<AccountDbModel>, IAccountRepositoryAsync
    {
        public AccountRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<AccountDbModel>> GetAccountsByOwner(Guid ownerId)
        {
            return await FindByCondition(a => a.OwnerId.Equals(ownerId)).ToListAsync();
        }

        public async Task<AccountDbModel?> GetAccountByOwner(Guid ownerId, Guid id)
        {
            return await FindByCondition(a => a.OwnerId.Equals(ownerId) && a.Id.Equals(id)).SingleOrDefaultAsync();
        }
    }
}
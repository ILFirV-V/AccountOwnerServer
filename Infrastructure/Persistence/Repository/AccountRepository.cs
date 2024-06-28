using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DbModels;
using Domain.Models;
using Domain.Models.Parameters;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Persistence.Helpers.interfaces;

namespace Persistence.Repository
{
    internal sealed class AccountRepository : RepositoryBase<AccountDbModel>, IAccountRepositoryAsync
    {
        private ISortHelper<AccountDbModel> sortHelper;

        public AccountRepository(RepositoryContext repositoryContext, ISortHelper<AccountDbModel> sortHelper)
            : base(repositoryContext)
        {
            this.sortHelper = sortHelper;
        }

        public async Task<bool> ExistsAny(Guid ownerId, CancellationToken cancellationToken = default)
        {
            return await FindByCondition(a => a.OwnerId.Equals(ownerId)).AnyAsync(cancellationToken);
        }

        public async Task<AccountDbModel?> GetAccountByOwner(Guid ownerId, Guid id, CancellationToken cancellationToken = default)
        {
            return await FindByCondition(a => a.OwnerId.Equals(ownerId) && a.Id.Equals(id)).SingleOrDefaultAsync(cancellationToken);
        }

        public async Task<IEnumerable<AccountDbModel>> GetAllByOwnerIdAsync(Guid ownerId, AccountParameters parameters, CancellationToken cancellationToken = default)
        {
            var accounts = FindByCondition(a => a.OwnerId.Equals(ownerId));
            accounts = ApplyDateFilters(accounts, parameters.MinDateCreated, parameters.MaxDateCreated);
            accounts = sortHelper.ApplySort(accounts, parameters.OrderBy);
            return await ApplyPagination(accounts, parameters.PageNumber, parameters.PageSize).ToListAsync(cancellationToken);
        }

        private IQueryable<AccountDbModel> ApplyDateFilters(IQueryable<AccountDbModel> accounts, DateTime startDate, DateTime endDate)
        {
            return accounts.Where(o => o.DateCreated >= startDate &&
                                o.DateCreated <= endDate);
        }

        private IQueryable<AccountDbModel> ApplyPagination(
            IQueryable<AccountDbModel> accounts,
            int pageNumber,
            int pageSize)
        {
            return accounts.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }
    }
}
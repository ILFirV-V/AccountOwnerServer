using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Domain.DbModels;
using Domain.Models;
using Domain.Models.Parameters;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Persistence.Helpers;
using Persistence.Helpers.interfaces;


namespace Persistence.Repository
{
    internal sealed class OwnerRepository : RepositoryBase<OwnerDbModel>, IOwnerRepositoryAsync
    {
        private ISortHelper<OwnerDbModel> ownerSortHelper;

        public OwnerRepository(RepositoryContext repositoryContext, ISortHelper<OwnerDbModel> ownerSortHelper)
            : base(repositoryContext)
        {
            this.ownerSortHelper = ownerSortHelper;
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

        public async Task<IEnumerable<OwnerDbModel>> GetAllOwnersAsync(OwnerParameters ownerParameters, CancellationToken cancellationToken = default)
        {
            var owners = FindAll();
            owners = ApplyDateFilters(owners, ownerParameters.MinDateOfBirth, ownerParameters.MaxDateOfBirth);
            owners = SearchByName(owners, ownerParameters.Name);
            owners = ownerSortHelper.ApplySort(owners, ownerParameters.OrderBy);
            return await ApplyPagination(owners, ownerParameters.PageNumber, ownerParameters.PageSize).ToListAsync(cancellationToken);
        }

        private IQueryable<OwnerDbModel> ApplyDateFilters(IQueryable<OwnerDbModel> owners, DateTime startDate, DateTime endDate)
        {
            return owners.Where(o => o.DateOfBirth >= startDate &&
                                o.DateOfBirth <= endDate);
        }

        private IQueryable<OwnerDbModel> SearchByName(IQueryable<OwnerDbModel> owners, string ownerName)
        {
            if (!owners.Any() || string.IsNullOrWhiteSpace(ownerName))
                return owners;
            return owners.Where(o => o.Name.ToLower().Contains(ownerName.Trim().ToLower()));
        }

        private IQueryable<OwnerDbModel> ApplyPagination(
            IQueryable<OwnerDbModel> owners,
            int pageNumber, 
            int pageSize)
        {
            return owners.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }
    }
}
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

namespace Persistence
{
    internal sealed class OwnerRepository : RepositoryBase<OwnerDbModel>, IOwnerRepositoryAsync
    {
        public OwnerRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<OwnerDbModel>> GetAllOwnersAsync(OwnerParameters ownerParameters, CancellationToken cancellationToken = default)
        {
            var owners = FindByCondition(o => o.DateOfBirth >= ownerParameters.MinDateOfBirth &&
                                o.DateOfBirth <= ownerParameters.MaxDateOfBirth);

            SearchByName(ref owners, ownerParameters.Name);

            return await owners.OrderBy(ow => ow.Name)
                .Skip((ownerParameters.PageNumber - 1) * ownerParameters.PageSize)
                .Take(ownerParameters.PageSize)
                .ToListAsync(cancellationToken);
        }

        private void SearchByName(ref IQueryable<OwnerDbModel> owners, string ownerName)
        {
            if (!owners.Any() || string.IsNullOrWhiteSpace(ownerName))
                return;
            owners = owners.Where(o => o.Name.ToLower().Contains(ownerName.Trim().ToLower()));
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
using Entities.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository
{
    public interface IOwnerRepositoryAsync : IRepositoryBase<OwnerDbModel>
    {
        Task<IEnumerable<OwnerDbModel>> GetAllOwnersAsync();
        Task<OwnerDbModel?> GetOwnerByIdAsync(Guid ownerId);
        Task<OwnerDbModel?> GetOwnerWithDetailsAsync(Guid ownerId);
    }
}
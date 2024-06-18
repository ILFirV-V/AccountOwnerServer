using Domain.DbModels;
using Domain.Models.Parameters;

namespace Domain.Repository
{
    public interface IOwnerRepositoryAsync : IRepositoryBase<OwnerDbModel>
    {
        Task<IEnumerable<OwnerDbModel>> GetAllOwnersAsync(OwnerParameters ownerParameters, CancellationToken cancellationToken = default);
        Task<OwnerDbModel?> GetOwnerByIdAsync(Guid ownerId, CancellationToken cancellationToken = default);
        Task<OwnerDbModel?> GetOwnerWithDetailsAsync(Guid ownerId, CancellationToken cancellationToken = default);
    }
}
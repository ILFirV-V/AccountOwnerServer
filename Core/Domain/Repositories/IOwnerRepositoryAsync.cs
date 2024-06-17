using Domain.DbModels;

namespace Domain.Repository
{
    public interface IOwnerRepositoryAsync : IRepositoryBase<OwnerDbModel>
    {
        Task<IEnumerable<OwnerDbModel>> GetAllOwnersAsync(CancellationToken cancellationToken = default);
        Task<OwnerDbModel?> GetOwnerByIdAsync(Guid ownerId, CancellationToken cancellationToken = default);
        Task<OwnerDbModel?> GetOwnerWithDetailsAsync(Guid ownerId, CancellationToken cancellationToken = default);
    }
}
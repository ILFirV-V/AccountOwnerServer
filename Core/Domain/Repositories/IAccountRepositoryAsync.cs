using Domain.DbModels;
using Domain.Models.Parameters;

namespace Domain.Repository
{
    public interface IAccountRepositoryAsync : IRepositoryBase<AccountDbModel>
    {
        Task<IEnumerable<AccountDbModel>> GetAllByOwnerIdAsync(Guid ownerId, GetItemsQuery parameters, CancellationToken cancellationToken = default);

        Task<bool> ExistsAny(Guid ownerId, CancellationToken cancellationToken = default);

        Task<AccountDbModel?> GetAccountByOwner(Guid ownerId, Guid id, CancellationToken cancellationToken = default);
    }
}
using Microsoft.EntityFrameworkCore.Storage;
using ProjectBase.Core.Entities;

namespace ProjectBase.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetById(int id, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<TEntity>> ListAll(CancellationToken cancellationToken = default);
        Task<TEntity> Add(TEntity entity, CancellationToken cancellationToken = default);
        Task Update(TEntity entity, CancellationToken cancellationToken = default);
        Task Delete(TEntity entity, CancellationToken cancellationToken = default);
        Task<IDbContextTransaction> BeginTransaction(CancellationToken cancellationToken = default);
    }
}

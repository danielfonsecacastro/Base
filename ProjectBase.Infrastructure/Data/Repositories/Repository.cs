using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ProjectBase.Core.Entities;
using ProjectBase.Core.Interfaces;

namespace ProjectBase.Infrastructure.Data.Repositories
{
    public class Repository<T> : IRepository<T>
        where T : BaseEntity
    {
        protected readonly ProjectBaseContext _dbContext;

        public Repository(ProjectBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> Add(T entity, CancellationToken cancellationToken = default)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public async Task<IDbContextTransaction> BeginTransaction(CancellationToken cancellationToken = default)
           => await _dbContext.Database.BeginTransactionAsync(cancellationToken);

        public async Task Delete(T entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<T> GetById(int id, CancellationToken cancellationToken = default)
        {
            var keyValues = new object[] { id };
            return await _dbContext.Set<T>().FindAsync(keyValues, cancellationToken);
        }

        public async Task<IReadOnlyList<T>> ListAll(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<T>().Where(x => x.IsDeleted == false).ToListAsync(cancellationToken);
        }

        public async Task Update(T entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}

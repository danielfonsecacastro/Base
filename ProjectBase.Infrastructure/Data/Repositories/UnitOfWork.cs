using Microsoft.EntityFrameworkCore.Storage;
using ProjectBase.Core.Interfaces;

namespace ProjectBase.Infrastructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ProjectBaseContext context)
        {
            _context = context;
            ClientRepository = new ClientRepository(_context);
            ClientContractRepository = new ClientContractRepository(_context);

        }

        private readonly ProjectBaseContext _context;
        private IDbContextTransaction _transaction;

        public IClientRepository ClientRepository { get; private set; }
        public IClientContractRepository ClientContractRepository { get; private set; }
       
        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task BeginTransaction()
        {
            if (_transaction == null)
            {
                _transaction = await _context.Database.BeginTransactionAsync();
            }
        }

        public async Task Commit()
        {
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public async Task Rollback()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public async void Dispose()
        {
            if (_transaction != null)
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }

            await _context.DisposeAsync();
        }
    }
}

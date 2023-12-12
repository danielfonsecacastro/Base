namespace ProjectBase.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IClientRepository ClientRepository { get; }
        IClientContractRepository ClientContractRepository { get; }
        Task<int> SaveChanges();
        Task BeginTransaction();
        Task Commit();
        Task Rollback();
    }
}

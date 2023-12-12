using ProjectBase.Core.Entities;

namespace ProjectBase.Core.Interfaces
{
    public interface IClientContractRepository : IRepository<ClientContract>
    {
        Task<List<ClientContract>> GetByClientId(int clientId, CancellationToken cancellationToken);
    }
}

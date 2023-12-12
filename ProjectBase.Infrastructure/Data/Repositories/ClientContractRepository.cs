using Microsoft.EntityFrameworkCore;
using ProjectBase.Core.Entities;
using ProjectBase.Core.Interfaces;

namespace ProjectBase.Infrastructure.Data.Repositories
{
    public class ClientContractRepository : Repository<ClientContract>, IClientContractRepository
    {
        public ClientContractRepository(ProjectBaseContext dbContext)
        : base(dbContext)
        { }

        public async Task<List<ClientContract>> GetByClientId(int clientId, CancellationToken cancellationToken)
            => await _dbContext.ClientContracts.Where(x => x.ClientId == clientId && x.IsDeleted == false).ToListAsync(cancellationToken);
    }
}

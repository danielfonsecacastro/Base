using ProjectBase.Core.Entities;
using ProjectBase.Core.Interfaces;

namespace ProjectBase.Infrastructure.Data.Repositories
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(ProjectBaseContext dbContext)
        : base(dbContext)
        { }
    }
}

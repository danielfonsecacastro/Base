using MediatR;

namespace ProjectBase.CQRS.Queries.Client
{
    public class QueryClientById : IRequest<Core.Entities.Client>
    {
        public QueryClientById(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}

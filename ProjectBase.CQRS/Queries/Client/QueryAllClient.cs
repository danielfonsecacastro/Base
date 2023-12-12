using MediatR;

namespace ProjectBase.CQRS.Queries.Client
{
    public class QueryAllClient : IRequest<IEnumerable<Core.Entities.Client>>
    {
    }
}

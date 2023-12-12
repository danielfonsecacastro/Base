using ProjectBase.Core.Interfaces;
using ProjectBase.CQRS.Queries.Client;
using MediatR;

namespace ProjectBase.CQRS.QueryHandlers.Client
{
    public class AllClientHandle : IRequestHandler<QueryAllClient, IEnumerable<Core.Entities.Client>>
    {
        public AllClientHandle(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private readonly IUnitOfWork _unitOfWork;
        public async Task<IEnumerable<Core.Entities.Client>> Handle(QueryAllClient request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.ClientRepository.ListAll(cancellationToken);
        }
    }
}

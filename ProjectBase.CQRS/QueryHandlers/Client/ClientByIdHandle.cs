using ProjectBase.Core.Interfaces;
using ProjectBase.CQRS.Queries.Client;
using MediatR;

namespace ProjectBase.CQRS.QueryHandlers.Client
{
    public class ClientByIdHandle : IRequestHandler<QueryClientById, Core.Entities.Client>
    {
        public ClientByIdHandle(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private readonly IUnitOfWork _unitOfWork;

        public async Task<Core.Entities.Client> Handle(QueryClientById request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.ClientRepository.GetById(request.Id, cancellationToken);
        }
    }
}

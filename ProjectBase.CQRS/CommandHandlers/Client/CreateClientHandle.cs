using ProjectBase.Core.Interfaces;
using ProjectBase.CQRS.Commands.Client;
using ProjectBase.CQRS.Support;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ProjectBase.CQRS.CommandHandlers.Client
{
    public class CreateClientHandle : IRequestHandler<CreateClientCommand, ICommandResult>
    {
        public CreateClientHandle(IUnitOfWork unitOfWork, ILogger<CreateClientHandle> logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public async Task<ICommandResult> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Adding new Client.");
            var entity = new Core.Entities.Client(businessName: request.BusinessName, cnpjNumber: request.CnpjNumber, manager: request.Manager, email: request.Email)
            {
                WhatsApp = request.WhatsApp,

            };
            await _unitOfWork.ClientRepository.Add(entity, cancellationToken);
            await _unitOfWork.SaveChanges();
            _logger.LogInformation("Saved changes to database.");

            return CommandResult.Ok(new { entity.Id });
        }
    }
}

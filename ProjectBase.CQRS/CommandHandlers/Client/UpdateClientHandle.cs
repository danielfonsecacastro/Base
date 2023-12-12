using ProjectBase.Core.Interfaces;
using ProjectBase.CQRS.Commands.Client;
using ProjectBase.CQRS.Support;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ProjectBase.CQRS.CommandHandlers.Client
{
    public class UpdateClientHandle : IRequestHandler<UpdateClientCommand, ICommandResult>
    {
        public UpdateClientHandle(IUnitOfWork unitOfWork, ILogger<UpdateClientHandle> logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public async Task<ICommandResult> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Updating Client.");
            var entity = await _unitOfWork.ClientRepository.GetById(request.Id, cancellationToken);
            
            entity.BusinessName = request.BusinessName;
            entity.CnpjNumber = request.CnpjNumber;
            entity.Manager = request.Manager;
            entity.Email = request.Email;
            entity.WhatsApp = request.WhatsApp;
            entity.UpdatedAt = DateTime.Now;
            
            await _unitOfWork.SaveChanges();
            _logger.LogInformation("Saved changes to database.");

            return CommandResult.Ok();
        }
    }
}

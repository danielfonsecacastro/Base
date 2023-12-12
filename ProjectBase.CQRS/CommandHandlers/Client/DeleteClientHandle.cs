using ProjectBase.Core.Interfaces;
using ProjectBase.CQRS.Commands.Client;
using ProjectBase.CQRS.Support;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ProjectBase.CQRS.CommandHandlers.Client
{
    public class DeleteClientHandle : IRequestHandler<DeleteClientCommand, ICommandResult>
    {
        public DeleteClientHandle(IUnitOfWork unitOfWork, ILogger<DeleteClientHandle> logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public async Task<ICommandResult> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Deleting Client.");
            var entity = await _unitOfWork.ClientRepository.GetById(request.Id, cancellationToken);
            
            entity.IsDeleted = true;
            entity.UpdatedAt = DateTime.Now;
            
            await _unitOfWork.SaveChanges();
            _logger.LogInformation("Saved changes to database.");

            return CommandResult.Ok();
        }
    }
}

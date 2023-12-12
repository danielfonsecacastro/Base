using ProjectBase.Core.Interfaces;
using MediatR;

namespace ProjectBase.CQRS.Commands.Client
{
    public class DeleteClientCommand : IRequest<ICommandResult>
    {
        public DeleteClientCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}

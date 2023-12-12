using ProjectBase.Core.Interfaces;
using MediatR;

namespace ProjectBase.CQRS.Commands.Client
{
    public class UpdateClientCommand : IRequest<ICommandResult>
    {
        public UpdateClientCommand(int id, string businessName, string cnpjNumber, string manager, string email)
        {
            Id = id;
            BusinessName = businessName;
            CnpjNumber = cnpjNumber;
            Manager = manager;
            Email = email;
        }

        public int Id { get; set; }
        public string BusinessName { get; set; }
        public string CnpjNumber { get; set; }
        public string Manager { get; set; }
        public string Email { get; set; }
        public string WhatsApp { get; set; }
    }
}

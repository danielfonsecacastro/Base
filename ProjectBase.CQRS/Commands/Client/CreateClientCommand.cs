using ProjectBase.Core.Interfaces;
using MediatR;

namespace ProjectBase.CQRS.Commands.Client
{
    public class CreateClientCommand : IRequest<ICommandResult>
    {
        public CreateClientCommand(string businessName, string cnpjNumber, string manager, string email)
        {
            BusinessName = businessName;
            CnpjNumber = cnpjNumber;
            Manager = manager;
            Email = email;
        }

        public string BusinessName { get; set; }
        public string CnpjNumber { get; set; }
        public string Manager { get; set; }
        public string Email { get; set; }
        public string WhatsApp { get; set; }
    }
}

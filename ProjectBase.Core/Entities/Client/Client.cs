using Ardalis.GuardClauses;

namespace ProjectBase.Core.Entities
{
    public class Client : BaseEntity
    {
        public Client()
        {
            //EF
        }

        public Client(string businessName, string cnpjNumber, string manager, string email)
        {
            BusinessName = Guard.Against.NullOrEmpty(businessName, nameof(businessName));
            CnpjNumber = Guard.Against.NullOrEmpty(cnpjNumber, nameof(cnpjNumber));
            Manager = Guard.Against.NullOrEmpty(manager, nameof(manager));
            Email = Guard.Against.NullOrEmpty(email, nameof(email));

            CreatedAt = DateTime.Now;
        }

        public string BusinessName { get; set; }
        public string CnpjNumber { get; set; }
        public string Manager { get; set; }
        public string Email { get; set; }
        public string WhatsApp { get; set; }
        public virtual ICollection<ClientContract> ClientContracts { get; set; }
    }
}

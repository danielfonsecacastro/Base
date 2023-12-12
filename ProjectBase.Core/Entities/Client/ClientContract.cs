using Ardalis.GuardClauses;

namespace ProjectBase.Core.Entities
{
    public class ClientContract : BaseEntity
    {
        public ClientContract()
        {
            //EF
        }

        public ClientContract(int clientId, string contractNumber, decimal totalContractValue, DateTime contractStart, DateTime contractEnd)
        {
            ClientId = Guard.Against.NegativeOrZero(clientId, nameof(clientId));
            ContractNumber = Guard.Against.NullOrEmpty(contractNumber, nameof(contractNumber));
            TotalContractValue = totalContractValue;
            ContractStart = Guard.Against.OutOfSQLDateRange(contractStart, nameof(contractStart));
            ContractEnd = Guard.Against.OutOfSQLDateRange(contractEnd, nameof(contractEnd));

            CreatedAt = DateTime.Now;
        }

        public string ContractNumber { get; set; }
        public decimal TotalContractValue { get; set; }
        public DateTime ContractStart { get; set; }
        public DateTime ContractEnd { get; set; }
        public virtual int ClientId { get; set; }
        public virtual Client Client { get; set; }

        public (bool, string) ValidateContractDates()
        {
            if (ContractStart >= ContractEnd)
            {
                return (false, $"Data de início: {ContractStart.ToShortDateString()} deve ser menor que a data fim: {ContractEnd.ToShortDateString()}");
            }

            return (true, string.Empty);
        }
    }
}

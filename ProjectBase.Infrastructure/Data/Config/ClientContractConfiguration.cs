using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectBase.Core.Entities;

namespace ProjectBase.Infrastructure.Data.Config
{
    public class ClientContractConfiguration : IEntityTypeConfiguration<ClientContract>
    {
        public void Configure(EntityTypeBuilder<ClientContract> builder)
        {
            builder.ToTable("ClientContracts");
            builder.HasKey(c => c.Id);


            builder.Property(c => c.ContractNumber)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(c => c.TotalContractValue)
                 .HasColumnType("decimal(18,2)");

            builder.Property(c => c.ContractStart)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(c => c.ContractEnd)
                .IsRequired()
                .HasColumnType("datetime");
        }
    }
}

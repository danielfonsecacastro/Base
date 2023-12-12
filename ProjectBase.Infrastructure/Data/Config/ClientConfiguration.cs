using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectBase.Core.Entities;

namespace ProjectBase.Infrastructure.Data.Config
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Clients");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.BusinessName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(c => c.CnpjNumber)
                .IsRequired()
                .HasMaxLength(255);


            builder.Property(c => c.Manager)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(c => c.WhatsApp)
                .HasMaxLength(255);

            // Define relationships
            builder.HasMany(c => c.ClientContracts)
             .WithOne(cp => cp.Client)
             .HasForeignKey(cp => cp.ClientId)
             .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

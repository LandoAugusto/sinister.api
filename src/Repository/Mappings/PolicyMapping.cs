using Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Mappings
{
    internal class PolicyMapping : IEntityTypeConfiguration<Policy>
    {
        public void Configure(EntityTypeBuilder<Policy> builder)
        {
            builder
           .HasKey(x => x.Id);

            builder
                .Property(e => e.CreatedDate).HasColumnType("datetime");

            builder
                .Property(e => e.EndOfTerm).HasColumnType("datetime");

            builder
                .Property(e => e.EndorsementId)
                .HasMaxLength(15)
                .IsUnicode(false);

            builder
                .Property(e => e.PolicyDate).HasColumnType("datetime");

            builder
                .Property(e => e.ProposalDate).HasColumnType("datetime");

            builder
                .Property(e => e.StartOfTerm).HasColumnType("datetime");

            builder
                .Property(e => e.UpdatedDate).HasColumnType("datetime");

            builder
                .HasOne(d => d.Product)
                .WithMany(p => p.Policies)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}

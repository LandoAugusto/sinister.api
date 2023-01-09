using Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Mappings
{
    internal class InsuredPhoneMapping : IEntityTypeConfiguration<InsuredPhone>
    {
        public void Configure(EntityTypeBuilder<InsuredPhone> builder)
        {
            builder
           .HasKey(x => x.Id);

            builder.Property(e => e.CreatedDate).HasColumnType("datetime");

            builder.Property(e => e.Ddd)
                .HasMaxLength(3)
                .IsUnicode(false);

            builder.Property(e => e.Phone)
                .HasMaxLength(14)
                .IsUnicode(false);

            builder.Property(e => e.UpdatedDate).HasColumnType("datetime");

            builder.HasOne(d => d.Insured)
                .WithMany(p => p.InsuredPhone)
                .HasForeignKey(d => d.InsuredId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.PhoneType)
                .WithMany(p => p.InsuredPhone)
                .HasForeignKey(d => d.PhoneTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}

using Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Mappings
{
    internal class InsuredAddressMapping : IEntityTypeConfiguration<InsuredAddress>
    {
        public void Configure(EntityTypeBuilder<InsuredAddress> builder)
        {
            builder
            .HasKey(x => x.Id);

            builder.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Complement)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.CreatedDate).HasColumnType("datetime");

            builder.Property(e => e.District)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Number)
                .HasMaxLength(15)
                .IsUnicode(false);

            builder.Property(e => e.StateInitials)
                .HasMaxLength(2)
                .IsUnicode(false);

            builder.Property(e => e.StateName)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.StreetName)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.UpdatedDate).HasColumnType("datetime");

            builder.Property(e => e.ZipCode)
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.HasOne(d => d.Insured)
                .WithMany(p => p.InsuredAddress)
                .HasForeignKey(d => d.InsuredId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}

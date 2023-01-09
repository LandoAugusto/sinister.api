using Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Mappings
{
    internal class InsuredEmailMapping : IEntityTypeConfiguration<InsuredEmail>
    {
        public void Configure(EntityTypeBuilder<InsuredEmail> builder)
        {
            builder
            .HasKey(x => x.Id);


            builder.Property(e => e.CreatedDate).HasColumnType("datetime");

            builder.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.UpdatedDate).HasColumnType("datetime");

            builder.HasOne(d => d.EmailType)
                .WithMany(p => p.InsuredEmail)
                .HasForeignKey(d => d.EmailTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.Insured)
                .WithMany(p => p.InsuredEmail)
                .HasForeignKey(d => d.InsuredId)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }
}

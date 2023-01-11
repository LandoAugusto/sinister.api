using Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Mappings
{
    internal class InsuredMapping : IEntityTypeConfiguration<Insured>
    {
        public void Configure(EntityTypeBuilder<Insured> builder)
        {
            builder
            .HasKey(x => x.Id);

            builder
                .Property(e => e.Activity)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder
                .Property(e => e.CreatedDate).HasColumnType("datetime");

            builder
                .Property(e => e.DateFoundation)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder
                .Property(e => e.Document)
                .HasMaxLength(20)
                .IsUnicode(false);

            builder
                .Property(e => e.EstimatedEquity).HasColumnType("decimal(18, 0)");

            builder
                .Property(e => e.MonthlyIncome).HasColumnType("decimal(18, 0)");

            builder
                .Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder
                .Property(e => e.Nationality)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder
                .Property(e => e.Profession)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder
                .Property(e => e.RegistrationMunicipal)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder
                .Property(e => e.Sex)
                .HasMaxLength(1)
                .IsUnicode(false);        

        }
    }
}

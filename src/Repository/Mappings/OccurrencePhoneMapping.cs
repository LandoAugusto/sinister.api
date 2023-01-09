using Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Mappings
{
    internal class OccurrencePhoneMapping : IEntityTypeConfiguration<OccurrencePhone>
    {
        public void Configure(EntityTypeBuilder<OccurrencePhone> builder)
        {
            builder
            .HasKey(x => x.Id);

            builder
                .Property(e => e.CreatedDate).HasColumnType("datetime");

            builder
                .Property(e => e.DDD)
                .HasMaxLength(3)
                .IsUnicode(false);

            builder
                .Property(e => e.Phone)
                .HasMaxLength(14)
                .IsUnicode(false);

            builder
                .Property(e => e.UpdatedDate).HasColumnType("datetime");

            builder
                .HasOne(d => d.Occurence)
                .WithMany(p => p.OccurencePhone)
                .HasForeignKey(d => d.OccurenceId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}

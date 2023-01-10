using Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Mappings
{
    internal class OccurrenceMapping : IEntityTypeConfiguration<Occurrence>
    {
        public void Configure(EntityTypeBuilder<Occurrence> builder)
        {
            builder
           .HasKey(x => x.Id);

            builder.Property(e => e.DateOccurrence)
                .HasMaxLength(12)
                .IsUnicode(false);

            builder.Property(e => e.DescriptionDamage)
                .HasMaxLength(300)
                .IsUnicode(false);

            builder.Property(e => e.DescriptonOccurrence)
                .HasMaxLength(300)
                .IsUnicode(false);

            builder.Property(e => e.TimeOccurrence)
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(e => e.UpdatedDate).HasColumnType("datetime");

            builder.HasOne(d => d.Notification)
                .WithMany(p => p.Occurence)
                .HasForeignKey(d => d.NotificationId)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }
}

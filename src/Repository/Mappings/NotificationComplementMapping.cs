using Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Mappings
{
    internal class NotificationComplementMapping : IEntityTypeConfiguration<NotificationComplement>
    {
        public void Configure(EntityTypeBuilder<NotificationComplement> builder)
        {
            builder
            .HasKey(x => x.Id);

            builder
            .Property(x => x.InclusionUserId);

            builder.HasOne(d => d.ProcessType)
               .WithMany(p => p.NotificationComplement)
               .HasForeignKey(d => d.ProcessTypeId)
               .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}

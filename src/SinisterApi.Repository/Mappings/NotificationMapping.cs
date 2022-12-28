using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SinisterApi.Domain.Entities;

namespace SinisterApi.Repository.Mappings
{
    internal class NotificationMapping : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder
            .HasKey(x => x.Id);

            builder
            .Property(x => x.InclusionUserId);

            builder
            .HasOne(d => d.Policy)
            .WithMany(p => p.Notifications)
            .HasForeignKey(d => d.PolicyId)
            .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.Situation)
            .WithMany(p => p.Notifications)
            .HasForeignKey(d => d.SituationId)
            .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.Status)
            .WithMany(p => p.Notifications)
            .HasForeignKey(d => d.StatusId)
            .OnDelete(DeleteBehavior.ClientSetNull);

           
        }
    }
}

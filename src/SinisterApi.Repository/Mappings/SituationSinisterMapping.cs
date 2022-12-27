using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SinisterApi.Domain.Entities;

namespace SinisterApi.Repository.Mappings
{
    internal class SituationSinisterMapping : IEntityTypeConfiguration<Situation>
    {
        public void Configure(EntityTypeBuilder<Situation> builder)
        {
            builder
           .HasKey(x => x.Id);

            builder
           .Property(x => x.Active);

            builder
           .Property(x => x.CreatedDate);

            builder
           .Property(x => x.UpdatedDate);
        }
    }
}
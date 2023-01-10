using Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Mappings
{
    internal class ProcessTypeMapping : IEntityTypeConfiguration<ProcessType>
    {
        public void Configure(EntityTypeBuilder<ProcessType> builder)
        {
            builder
           .HasKey(x => x.Id);

            builder
           .Property(x => x.Active);

            builder
           .Property(x => x.InclusionUserId);

            builder
           .Property(x => x.CreatedDate);

            builder
           .Property(x => x.UpdatedDate);
        }
    }
}   
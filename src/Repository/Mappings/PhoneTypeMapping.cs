using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Core.Entities;

namespace Infrastructure.Data.Repository.Mappings
{
    internal class PhoneTypeMapping : IEntityTypeConfiguration<PhoneType>
    {
        public void Configure(EntityTypeBuilder<PhoneType> builder)
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


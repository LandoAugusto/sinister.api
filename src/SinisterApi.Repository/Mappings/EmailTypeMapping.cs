using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SinisterApi.Domain.Entities;

namespace SinisterApi.Repository.Mappings
{
    internal class EmailTypeMapping : IEntityTypeConfiguration<EmailType>
    {
        public void Configure(EntityTypeBuilder<EmailType> builder)
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



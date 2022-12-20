using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SinisterApi.Domain.Entities;

namespace SinisterApi.Repository.Mappings
{
    internal class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
           .HasKey(x => x.ProductId);

            builder
           .Property(x => x.Description);

            builder
           .Property(x => x.ExternalId);

            builder
           .Property(x => x.ImageUrl);

            builder
           .Property(x => x.Active);

            builder
           .Property(x => x.CreatedDt);

            builder
           .Property(x => x.UpdatedDt);
        }
    }
}

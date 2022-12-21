using Microsoft.EntityFrameworkCore;
using SinisterApi.Domain.Entities;

namespace SinisterApi.Repository.Contexts
{
    internal class SinisterDbContext : DbContext
    {
        public SinisterDbContext()
        {
        }

        public SinisterDbContext(DbContextOptions<SinisterDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PeriodType> PeriodType { get; set; }
        public virtual DbSet<CommunicantType> CommunicantType { get; set; }
        public virtual DbSet<StatusSinister> StatusSinister { get; set; }
        public virtual DbSet<Product> Product { get; set; }
    }
}

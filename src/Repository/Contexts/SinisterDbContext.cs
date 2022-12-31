using Microsoft.EntityFrameworkCore;
using Domain.Core.Entities;

namespace Infrastructure.Data.Repository.Contexts   
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
        public virtual DbSet<PhoneType> PhoneType { get; set; }
        public virtual DbSet<EmailType> EmailType { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Situation> Situation{ get; set; }
        public virtual DbSet<Product> Product { get; set; }
    }
}

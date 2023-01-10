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
        public virtual DbSet<Communicant> Communicant { get; set; } = null!;        
        public virtual DbSet<CommunicantType> CommunicantType { get; set; }
        public virtual DbSet<CommunicantEmail> CommunicantEmail { get; set; } = null!;
        public virtual DbSet<CommunicantPhone> CommunicantPhone { get; set; } = null!;
        public virtual DbSet<PeriodType> PeriodType { get; set; } = null!;
        public virtual DbSet<PhoneType> PhoneType { get; set; } = null!;
        public virtual DbSet<EmailType> EmailType { get; set; } = null!;
        public virtual DbSet<Status> Status { get; set; } = null!;
        public virtual DbSet<Situation> Situation{ get; set; } = null!;
        public virtual DbSet<Product> Product { get; set; } = null!;
        public virtual DbSet<Occurrence> Occurrence { get; set; } = null!;
        public virtual DbSet<OccurrenceAddress> OccurrenceAddress { get; set; } = null!;
        public virtual DbSet<OccurrencePhone> OccurrencePhone { get; set; } = null!;
        public virtual DbSet<Insured> Insured { get; set; } = null!;
        public virtual DbSet<InsuredAddress> InsuredAddress { get; set; } = null!;
        public virtual DbSet<InsuredEmail> InsuredEmail { get; set; } = null!;
        public virtual DbSet<InsuredPhone> InsuredPhone { get; set; } = null!;
        public virtual DbSet<Policy> Policy { get; set; } = null!;
        public virtual DbSet<NotificationComplement> NotificationComplement { get; set; } = null!;
        public virtual DbSet<ProcessType> ProcessType { get; set; } = null!;
    }
}

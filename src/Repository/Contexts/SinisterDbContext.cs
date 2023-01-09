﻿using Microsoft.EntityFrameworkCore;
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
        public virtual DbSet<CommunicantEmail> CommunicantEmails { get; set; } = null!;
        public virtual DbSet<CommunicantPhone> CommunicantPhones { get; set; } = null!;
        public virtual DbSet<PeriodType> PeriodType { get; set; }
        public virtual DbSet<PhoneType> PhoneType { get; set; }
        public virtual DbSet<EmailType> EmailType { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Situation> Situation{ get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Occurrence> Occurence { get; set; } = null!;
        public virtual DbSet<OccurrenceAddrress> OccurrenceAddrress { get; set; } = null!;
        public virtual DbSet<OccurrencePhone> OccurencePhone { get; set; } = null!;
        public virtual DbSet<Insured> Insured { get; set; } = null!;
        public virtual DbSet<InsuredAddress> InsuredAddress { get; set; } = null!;
        public virtual DbSet<InsuredEmail> InsuredEmail { get; set; } = null!;
        public virtual DbSet<InsuredPhone> InsuredPhone { get; set; } = null!;
        public virtual DbSet<Policy> Policies { get; set; } = null!;
    }
}

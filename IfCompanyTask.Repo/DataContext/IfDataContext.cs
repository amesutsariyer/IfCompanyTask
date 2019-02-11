using IfCompany.Entity.Repository;
using IfCompanyTask.Entity.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IfCompanyTask.Repository.DataContext
{
    public class IfDataContext : DbContext
    {
        //public string ConnectionString { get; set; }

        public IfDataContext(DbContextOptions<IfDataContext> options) : base(options)
        {
        }

        public DbSet<Risk> Risks { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<RiskPolicyAudit> RiskPolicyAudits { get; set; }
        public DbSet<PolicyAudit> PolicyAudits { get; set; }
        public DbSet<InsuranceCompany> InsuranceCompanies { get; set; }
        public DbSet<LogResourceAPI> LogResource { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Risk>().ToTable("Risk");
            builder.Entity<Policy>().ToTable("Policy");
            builder.Entity<PolicyAudit>().ToTable("PolicyAudit");
            builder.Entity<LogResourceAPI>().ToTable("Log");
            builder.Entity<InsuranceCompany>().ToTable("InsuranceCompany");
            builder.Entity<RiskPolicyAudit>().ToTable("RiskPolicyAudit");
        }
    }
}

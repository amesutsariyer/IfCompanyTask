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


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Risk>().ToTable("Risk");
            builder.Entity<Policy>().ToTable("Policy");
        }
    }
}

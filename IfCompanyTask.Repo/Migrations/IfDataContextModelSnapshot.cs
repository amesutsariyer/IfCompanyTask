﻿// <auto-generated />
using System;
using IfCompanyTask.Repository.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IfCompanyTask.Repository.Migrations
{
    [DbContext(typeof(IfDataContext))]
    partial class IfDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IfCompany.Entity.Repository.InsuranceCompany", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("InsuranceCompany");
                });

            modelBuilder.Entity("IfCompany.Entity.Repository.LogResourceAPI", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("Exception");

                    b.Property<string>("Level");

                    b.Property<string>("Message");

                    b.Property<string>("MessageTemplate");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Properties");

                    b.Property<DateTime>("TimeStamp");

                    b.HasKey("Id");

                    b.ToTable("Log");
                });

            modelBuilder.Entity("IfCompany.Entity.Repository.PolicyAudit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int>("PolicyId");

                    b.Property<decimal>("Premium");

                    b.Property<DateTime>("ValidFrom");

                    b.Property<short>("ValidMonths");

                    b.Property<DateTime>("ValidTill");

                    b.HasKey("Id");

                    b.HasIndex("PolicyId");

                    b.ToTable("PolicyAudit");
                });

            modelBuilder.Entity("IfCompany.Entity.Repository.RiskPolicyAudit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<int>("PolicyAuditId");

                    b.Property<int>("RiskId");

                    b.Property<DateTime>("ValidFrom");

                    b.HasKey("Id");

                    b.HasIndex("PolicyAuditId");

                    b.HasIndex("RiskId");

                    b.ToTable("RiskPolicyAudit");
                });

            modelBuilder.Entity("IfCompanyTask.Entity.Repository.Policy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("NameOfInsuredObject");

                    b.Property<decimal>("Premium");

                    b.Property<DateTime>("ValidFrom");

                    b.Property<DateTime>("ValidTill");

                    b.HasKey("Id");

                    b.ToTable("Policy");
                });

            modelBuilder.Entity("IfCompanyTask.Entity.Repository.Risk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<DateTime?>("ModifiedDate");

                    b.Property<string>("Name");

                    b.Property<decimal>("YearlyPrice");

                    b.HasKey("Id");

                    b.ToTable("Risk");
                });

            modelBuilder.Entity("IfCompany.Entity.Repository.PolicyAudit", b =>
                {
                    b.HasOne("IfCompanyTask.Entity.Repository.Policy", "Policy")
                        .WithMany()
                        .HasForeignKey("PolicyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IfCompany.Entity.Repository.RiskPolicyAudit", b =>
                {
                    b.HasOne("IfCompany.Entity.Repository.PolicyAudit", "Policy")
                        .WithMany()
                        .HasForeignKey("PolicyAuditId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IfCompanyTask.Entity.Repository.Risk", "Risk")
                        .WithMany()
                        .HasForeignKey("RiskId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

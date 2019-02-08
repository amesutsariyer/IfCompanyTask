﻿// <auto-generated />
using System;
using IfCompanyTask.Repository.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IfCompanyTask.Repository.Migrations
{
    [DbContext(typeof(IfDataContext))]
    [Migration("20190207181902_Db-Design-Add-RElational")]
    partial class DbDesignAddRElational
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IfCompanyTask.Entity.Repository.Policy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("ModifiedDate");

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

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Name");

                    b.Property<int?>("PolicyId");

                    b.Property<decimal>("YearlyPrice");

                    b.HasKey("Id");

                    b.HasIndex("PolicyId");

                    b.ToTable("Risk");
                });

            modelBuilder.Entity("IfCompanyTask.Entity.Repository.Risk", b =>
                {
                    b.HasOne("IfCompanyTask.Entity.Repository.Policy", "Policy")
                        .WithMany("InsuredRisks")
                        .HasForeignKey("PolicyId");
                });
#pragma warning restore 612, 618
        }
    }
}
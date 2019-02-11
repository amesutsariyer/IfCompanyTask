using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IfCompanyTask.Repository.Migrations
{
    public partial class recreate5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InsuranceCompany",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceCompany", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    MessageTemplate = table.Column<string>(nullable: true),
                    Level = table.Column<string>(nullable: true),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    Exception = table.Column<string>(nullable: true),
                    Properties = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Policy",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    NameOfInsuredObject = table.Column<string>(nullable: true),
                    ValidFrom = table.Column<DateTime>(nullable: false),
                    ValidTill = table.Column<DateTime>(nullable: false),
                    Premium = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Risk",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    YearlyPrice = table.Column<decimal>(nullable: false),
                    InsuranceCompanyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Risk", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Risk_InsuranceCompany_InsuranceCompanyId",
                        column: x => x.InsuranceCompanyId,
                        principalTable: "InsuranceCompany",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PolicyAudit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    PolicyId = table.Column<int>(nullable: false),
                    ValidFrom = table.Column<DateTime>(nullable: false),
                    ValidMonths = table.Column<short>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Premium = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyAudit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PolicyAudit_Policy_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "Policy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RiskPolicyAudit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    PolicyAuditId = table.Column<int>(nullable: false),
                    RiskId = table.Column<int>(nullable: false),
                    ValidFrom = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiskPolicyAudit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RiskPolicyAudit_PolicyAudit_PolicyAuditId",
                        column: x => x.PolicyAuditId,
                        principalTable: "PolicyAudit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RiskPolicyAudit_Risk_RiskId",
                        column: x => x.RiskId,
                        principalTable: "Risk",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PolicyAudit_PolicyId",
                table: "PolicyAudit",
                column: "PolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_Risk_InsuranceCompanyId",
                table: "Risk",
                column: "InsuranceCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskPolicyAudit_PolicyAuditId",
                table: "RiskPolicyAudit",
                column: "PolicyAuditId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskPolicyAudit_RiskId",
                table: "RiskPolicyAudit",
                column: "RiskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "RiskPolicyAudit");

            migrationBuilder.DropTable(
                name: "PolicyAudit");

            migrationBuilder.DropTable(
                name: "Risk");

            migrationBuilder.DropTable(
                name: "Policy");

            migrationBuilder.DropTable(
                name: "InsuranceCompany");
        }
    }
}

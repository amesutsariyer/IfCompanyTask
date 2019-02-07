using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IfCompanyTask.Repository.Migrations
{
    public partial class DbDesignAddRelational10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InsuranceCompanyId",
                table: "Risk",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Risk_InsuranceCompanyId",
                table: "Risk",
                column: "InsuranceCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Risk_InsuranceCompany_InsuranceCompanyId",
                table: "Risk",
                column: "InsuranceCompanyId",
                principalTable: "InsuranceCompany",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Risk_InsuranceCompany_InsuranceCompanyId",
                table: "Risk");

            migrationBuilder.DropTable(
                name: "InsuranceCompany");

            migrationBuilder.DropIndex(
                name: "IX_Risk_InsuranceCompanyId",
                table: "Risk");

            migrationBuilder.DropColumn(
                name: "InsuranceCompanyId",
                table: "Risk");
        }
    }
}

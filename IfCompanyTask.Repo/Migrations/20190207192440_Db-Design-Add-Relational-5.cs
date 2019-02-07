using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IfCompanyTask.Repository.Migrations
{
    public partial class DbDesignAddRelational5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Risk_Policy_PolicyId",
                table: "Risk");

            migrationBuilder.AlterColumn<int>(
                name: "PolicyId",
                table: "Risk",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "Risk",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Risk",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Risk",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InsuranceCompanyId",
                table: "Risk",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "Policy",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Policy",
                nullable: true,
                oldClrType: typeof(DateTime));

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

            migrationBuilder.AddForeignKey(
                name: "FK_Risk_Policy_PolicyId",
                table: "Risk",
                column: "PolicyId",
                principalTable: "Policy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Risk_InsuranceCompany_InsuranceCompanyId",
                table: "Risk");

            migrationBuilder.DropForeignKey(
                name: "FK_Risk_Policy_PolicyId",
                table: "Risk");

            migrationBuilder.DropTable(
                name: "InsuranceCompany");

            migrationBuilder.DropIndex(
                name: "IX_Risk_InsuranceCompanyId",
                table: "Risk");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Risk");

            migrationBuilder.DropColumn(
                name: "InsuranceCompanyId",
                table: "Risk");

            migrationBuilder.AlterColumn<int>(
                name: "PolicyId",
                table: "Risk",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "Risk",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Risk",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "Policy",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Policy",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Risk_Policy_PolicyId",
                table: "Risk",
                column: "PolicyId",
                principalTable: "Policy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

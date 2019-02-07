using Microsoft.EntityFrameworkCore.Migrations;

namespace IfCompanyTask.Repository.Migrations
{
    public partial class DbDesignAddRelational6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Risk_InsuranceCompany_InsuranceCompanyId",
                table: "Risk");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Risk");

            migrationBuilder.AlterColumn<int>(
                name: "InsuranceCompanyId",
                table: "Risk",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Risk_InsuranceCompany_InsuranceCompanyId",
                table: "Risk",
                column: "InsuranceCompanyId",
                principalTable: "InsuranceCompany",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Risk_InsuranceCompany_InsuranceCompanyId",
                table: "Risk");

            migrationBuilder.AlterColumn<int>(
                name: "InsuranceCompanyId",
                table: "Risk",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Risk",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Risk_InsuranceCompany_InsuranceCompanyId",
                table: "Risk",
                column: "InsuranceCompanyId",
                principalTable: "InsuranceCompany",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

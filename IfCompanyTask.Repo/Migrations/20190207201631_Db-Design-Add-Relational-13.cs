using Microsoft.EntityFrameworkCore.Migrations;

namespace IfCompanyTask.Repository.Migrations
{
    public partial class DbDesignAddRelational13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Risk_InsuranceCompany_InsuranceCompanyId",
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

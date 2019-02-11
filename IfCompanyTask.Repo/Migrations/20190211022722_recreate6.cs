using Microsoft.EntityFrameworkCore.Migrations;

namespace IfCompanyTask.Repository.Migrations
{
    public partial class recreate6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Risk_InsuranceCompany_InsuranceCompanyId",
                table: "Risk");

            migrationBuilder.DropIndex(
                name: "IX_Risk_InsuranceCompanyId",
                table: "Risk");

            migrationBuilder.DropColumn(
                name: "InsuranceCompanyId",
                table: "Risk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InsuranceCompanyId",
                table: "Risk",
                nullable: true);

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
    }
}

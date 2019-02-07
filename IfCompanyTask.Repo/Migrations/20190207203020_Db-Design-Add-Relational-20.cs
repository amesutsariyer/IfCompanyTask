using Microsoft.EntityFrameworkCore.Migrations;

namespace IfCompanyTask.Repository.Migrations
{
    public partial class DbDesignAddRelational20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InsuranceCompanyId",
                table: "Policy",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Policy_InsuranceCompanyId",
                table: "Policy",
                column: "InsuranceCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Policy_InsuranceCompany_InsuranceCompanyId",
                table: "Policy",
                column: "InsuranceCompanyId",
                principalTable: "InsuranceCompany",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Policy_InsuranceCompany_InsuranceCompanyId",
                table: "Policy");

            migrationBuilder.DropIndex(
                name: "IX_Policy_InsuranceCompanyId",
                table: "Policy");

            migrationBuilder.DropColumn(
                name: "InsuranceCompanyId",
                table: "Policy");
        }
    }
}

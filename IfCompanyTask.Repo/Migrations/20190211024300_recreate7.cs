using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IfCompanyTask.Repository.Migrations
{
    public partial class recreate7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ValidTill",
                table: "PolicyAudit",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValidTill",
                table: "PolicyAudit");
        }
    }
}

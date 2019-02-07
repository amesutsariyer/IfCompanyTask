 using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IfCompanyTask.Repository.Migrations
{
    public partial class DbDesignAddRElational : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PolicyId",
                table: "Risk",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameOfInsuredObject",
                table: "Policy",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Premium",
                table: "Policy",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidFrom",
                table: "Policy",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidTill",
                table: "Policy",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Risk_PolicyId",
                table: "Risk",
                column: "PolicyId");

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
                name: "FK_Risk_Policy_PolicyId",
                table: "Risk");

            migrationBuilder.DropIndex(
                name: "IX_Risk_PolicyId",
                table: "Risk");

            migrationBuilder.DropColumn(
                name: "PolicyId",
                table: "Risk");

            migrationBuilder.DropColumn(
                name: "NameOfInsuredObject",
                table: "Policy");

            migrationBuilder.DropColumn(
                name: "Premium",
                table: "Policy");

            migrationBuilder.DropColumn(
                name: "ValidFrom",
                table: "Policy");

            migrationBuilder.DropColumn(
                name: "ValidTill",
                table: "Policy");
        }
    }
}

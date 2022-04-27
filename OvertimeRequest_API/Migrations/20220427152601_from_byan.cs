using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OvertimeRequest_API.Migrations
{
    public partial class from_byan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Describe",
                table: "EmployeeOvertime");

            migrationBuilder.DropColumn(
                name: "Finish",
                table: "EmployeeOvertime");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "EmployeeOvertime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Describe",
                table: "EmployeeOvertime",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Finish",
                table: "EmployeeOvertime",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Start",
                table: "EmployeeOvertime",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

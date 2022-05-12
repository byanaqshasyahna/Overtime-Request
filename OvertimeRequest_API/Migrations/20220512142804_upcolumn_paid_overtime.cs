using Microsoft.EntityFrameworkCore.Migrations;

namespace OvertimeRequest_API.Migrations
{
    public partial class upcolumn_paid_overtime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Paid",
                table: "Activity");

            migrationBuilder.AddColumn<int>(
                name: "Paid",
                table: "Overtime",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Paid",
                table: "Overtime");

            migrationBuilder.AddColumn<int>(
                name: "Paid",
                table: "Activity",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

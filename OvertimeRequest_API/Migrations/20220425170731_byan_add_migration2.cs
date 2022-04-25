using Microsoft.EntityFrameworkCore.Migrations;

namespace OvertimeRequest_API.Migrations
{
    public partial class byan_add_migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeOvertime_Employee_EmployeeNIP",
                table: "EmployeeOvertime");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeOvertime_EmployeeNIP",
                table: "EmployeeOvertime");

            migrationBuilder.DropColumn(
                name: "EmployeeNIP",
                table: "EmployeeOvertime");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeOvertime_Employee_NIP",
                table: "EmployeeOvertime",
                column: "NIP",
                principalTable: "Employee",
                principalColumn: "NIP",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeOvertime_Employee_NIP",
                table: "EmployeeOvertime");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeNIP",
                table: "EmployeeOvertime",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeOvertime_EmployeeNIP",
                table: "EmployeeOvertime",
                column: "EmployeeNIP");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeOvertime_Employee_EmployeeNIP",
                table: "EmployeeOvertime",
                column: "EmployeeNIP",
                principalTable: "Employee",
                principalColumn: "NIP",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

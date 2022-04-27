using Microsoft.EntityFrameworkCore.Migrations;

namespace OvertimeRequest_API.Migrations
{
    public partial class edit_overtime_models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Overtime",
                newName: "OvertimeDate");

            migrationBuilder.RenameColumn(
                name: "Create_date",
                table: "Overtime",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "Approve_Manager",
                table: "Overtime",
                newName: "ManagerApprove");

            migrationBuilder.RenameColumn(
                name: "Approve_Finance",
                table: "Overtime",
                newName: "FinanceApprove");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OvertimeDate",
                table: "Overtime",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "ManagerApprove",
                table: "Overtime",
                newName: "Approve_Manager");

            migrationBuilder.RenameColumn(
                name: "FinanceApprove",
                table: "Overtime",
                newName: "Approve_Finance");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Overtime",
                newName: "Create_date");
        }
    }
}

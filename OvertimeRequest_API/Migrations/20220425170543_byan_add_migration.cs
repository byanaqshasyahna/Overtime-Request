using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OvertimeRequest_API.Migrations
{
    public partial class byan_add_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Overtime",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Create_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Approve_Finance = table.Column<int>(type: "int", nullable: false),
                    Approve_Manager = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Overtime", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeOvertime",
                columns: table => new
                {
                    NIP = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OvertimeId = table.Column<int>(type: "int", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Finish = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Describe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeNIP = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeOvertime", x => new { x.NIP, x.OvertimeId });
                    table.ForeignKey(
                        name: "FK_EmployeeOvertime_Employee_EmployeeNIP",
                        column: x => x.EmployeeNIP,
                        principalTable: "Employee",
                        principalColumn: "NIP",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeOvertime_Overtime_OvertimeId",
                        column: x => x.OvertimeId,
                        principalTable: "Overtime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeOvertime_EmployeeNIP",
                table: "EmployeeOvertime",
                column: "EmployeeNIP");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeOvertime_OvertimeId",
                table: "EmployeeOvertime",
                column: "OvertimeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeOvertime");

            migrationBuilder.DropTable(
                name: "Overtime");
        }
    }
}

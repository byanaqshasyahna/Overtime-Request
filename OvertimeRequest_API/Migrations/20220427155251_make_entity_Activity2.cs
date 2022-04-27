using Microsoft.EntityFrameworkCore.Migrations;

namespace OvertimeRequest_API.Migrations
{
    public partial class make_entity_Activity2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_Overtime_OvertimeId",
                table: "Activity");

            migrationBuilder.AlterColumn<int>(
                name: "OvertimeId",
                table: "Activity",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_Overtime_OvertimeId",
                table: "Activity",
                column: "OvertimeId",
                principalTable: "Overtime",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_Overtime_OvertimeId",
                table: "Activity");

            migrationBuilder.AlterColumn<int>(
                name: "OvertimeId",
                table: "Activity",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_Overtime_OvertimeId",
                table: "Activity",
                column: "OvertimeId",
                principalTable: "Overtime",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

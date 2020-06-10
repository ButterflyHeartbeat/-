using Microsoft.EntityFrameworkCore.Migrations;

namespace Inte_InpatientCare.Migrations
{
    public partial class removes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sex",
                table: "InPatients");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Sex",
                table: "InPatients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "InPatients",
                keyColumn: "ID",
                keyValue: 11,
                column: "Sex",
                value: 1);

            migrationBuilder.UpdateData(
                table: "InPatients",
                keyColumn: "ID",
                keyValue: 12,
                column: "Sex",
                value: 1);
        }
    }
}

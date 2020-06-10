using Microsoft.EntityFrameworkCore.Migrations;

namespace Inte_InpatientCare.Migrations
{
    public partial class adds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "InPatients",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sex",
                table: "InPatients",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "InPatients");

            migrationBuilder.DropColumn(
                name: "Sex",
                table: "InPatients");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Inte_InpatientCare.Migrations
{
    public partial class seedInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "InPatients",
                columns: new[] { "ID", "Chaperone", "InPatCard", "Name", "Sex" },
                values: new object[] { 11, "毛", "16122315", "闫高伟", 1 });

            migrationBuilder.InsertData(
                table: "InPatients",
                columns: new[] { "ID", "Chaperone", "InPatCard", "Name", "Sex" },
                values: new object[] { 12, "烟", "16122315", "毛子轩", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "InPatients",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "InPatients",
                keyColumn: "ID",
                keyValue: 12);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_Store.Persistance.Migrations
{
    public partial class Addroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1L, "Admin" });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2L, "Operator" });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3L, "Customer" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 3L);
        }
    }
}

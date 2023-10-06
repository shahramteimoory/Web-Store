using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_Store.Persistance.Migrations
{
    public partial class addNameinsiler : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "sliders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2023, 10, 6, 0, 36, 55, 880, DateTimeKind.Local).AddTicks(8346));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2023, 10, 6, 0, 36, 55, 882, DateTimeKind.Local).AddTicks(3098));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2023, 10, 6, 0, 36, 55, 882, DateTimeKind.Local).AddTicks(3187));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "sliders");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2023, 10, 5, 16, 22, 49, 965, DateTimeKind.Local).AddTicks(5031));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2023, 10, 5, 16, 22, 49, 967, DateTimeKind.Local).AddTicks(4257));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2023, 10, 5, 16, 22, 49, 967, DateTimeKind.Local).AddTicks(4337));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_Store.Persistance.Migrations
{
    public partial class add_ViewCountInProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2023, 10, 4, 10, 37, 27, 523, DateTimeKind.Local).AddTicks(4831));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2023, 10, 4, 10, 37, 27, 525, DateTimeKind.Local).AddTicks(424));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2023, 10, 4, 10, 37, 27, 525, DateTimeKind.Local).AddTicks(518));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "products");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2023, 9, 30, 16, 19, 20, 791, DateTimeKind.Local).AddTicks(9162));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2023, 9, 30, 16, 19, 20, 793, DateTimeKind.Local).AddTicks(3682));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2023, 9, 30, 16, 19, 20, 793, DateTimeKind.Local).AddTicks(3775));
        }
    }
}

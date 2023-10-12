using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_Store.Persistance.Migrations
{
    public partial class @base : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "InsertTime",
                table: "UserInRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "UserInRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemoveTime",
                table: "UserInRoles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "UserInRoles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertTime",
                table: "roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemoveTime",
                table: "roles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "roles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2023, 9, 28, 0, 50, 5, 595, DateTimeKind.Local).AddTicks(8307));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2023, 9, 28, 0, 50, 5, 597, DateTimeKind.Local).AddTicks(4470));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2023, 9, 28, 0, 50, 5, 597, DateTimeKind.Local).AddTicks(4729));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InsertTime",
                table: "UserInRoles");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "UserInRoles");

            migrationBuilder.DropColumn(
                name: "RemoveTime",
                table: "UserInRoles");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "UserInRoles");

            migrationBuilder.DropColumn(
                name: "InsertTime",
                table: "roles");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "roles");

            migrationBuilder.DropColumn(
                name: "RemoveTime",
                table: "roles");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "roles");
        }
    }
}

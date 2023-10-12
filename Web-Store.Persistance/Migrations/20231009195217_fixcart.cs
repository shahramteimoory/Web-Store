using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_Store.Persistance.Migrations
{
    public partial class fixcart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_carts_users_UserId",
                table: "carts");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "carts",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2023, 10, 9, 23, 22, 17, 63, DateTimeKind.Local).AddTicks(254));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2023, 10, 9, 23, 22, 17, 64, DateTimeKind.Local).AddTicks(4546));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2023, 10, 9, 23, 22, 17, 64, DateTimeKind.Local).AddTicks(4623));

            migrationBuilder.AddForeignKey(
                name: "FK_carts_users_UserId",
                table: "carts",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_carts_users_UserId",
                table: "carts");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "carts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2023, 10, 9, 18, 57, 29, 664, DateTimeKind.Local).AddTicks(4529));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2023, 10, 9, 18, 57, 29, 665, DateTimeKind.Local).AddTicks(8885));

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2023, 10, 9, 18, 57, 29, 665, DateTimeKind.Local).AddTicks(8970));

            migrationBuilder.AddForeignKey(
                name: "FK_carts_users_UserId",
                table: "carts",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

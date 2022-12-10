using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSchemaDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Todo",
                keyColumns: new[] { "Category", "Header" },
                keyValues: new object[] { (byte)3, "Create a ticket" });

            migrationBuilder.DeleteData(
                table: "Todo",
                keyColumns: new[] { "Category", "Header" },
                keyValues: new object[] { (byte)1, "Request information" });

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Todo",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<Guid>(
                name: "TodoId",
                table: "Comment",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: 1,
                column: "TodoId",
                value: new Guid("3540cb77-2ee4-4b5f-82cd-7f791b0e452a"));

            migrationBuilder.InsertData(
                table: "Todo",
                columns: new[] { "Category", "Header", "Color", "CreatedOn", "Id", "Status" },
                values: new object[,]
                {
                    { (byte)3, "Create a ticket", "Red", new DateTime(2022, 12, 10, 21, 31, 46, 261, DateTimeKind.Utc).AddTicks(3937), new Guid("3540cb77-2ee4-4b5f-82cd-7f791b0e452a"), (byte)0 },
                    { (byte)1, "Request information", "Green", new DateTime(2022, 12, 10, 21, 31, 46, 261, DateTimeKind.Utc).AddTicks(3939), new Guid("71e0eb6b-4861-4047-9512-91c400519763"), (byte)0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Todo",
                keyColumns: new[] { "Category", "Header" },
                keyValues: new object[] { (byte)3, "Create a ticket" });

            migrationBuilder.DeleteData(
                table: "Todo",
                keyColumns: new[] { "Category", "Header" },
                keyValues: new object[] { (byte)1, "Request information" });

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Todo",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "TodoId",
                table: "Comment",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: 1,
                column: "TodoId",
                value: 1);

            migrationBuilder.InsertData(
                table: "Todo",
                columns: new[] { "Category", "Header", "Color", "CreatedOn", "Id", "Status" },
                values: new object[,]
                {
                    { (byte)3, "Create a ticket", "Red", new DateTime(2022, 12, 10, 21, 5, 38, 706, DateTimeKind.Utc).AddTicks(8570), 1, (byte)0 },
                    { (byte)1, "Request information", "Green", new DateTime(2022, 12, 10, 21, 5, 38, 706, DateTimeKind.Utc).AddTicks(8572), 2, (byte)0 }
                });
        }
    }
}

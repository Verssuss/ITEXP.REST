using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FillData : Migration
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

            migrationBuilder.UpdateData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: 1,
                column: "TodoId",
                value: new Guid("ba2b3a4b-754e-464b-b02d-faea77f0eeb0"));

            migrationBuilder.InsertData(
                table: "Todo",
                columns: new[] { "Category", "Header", "Color", "CreatedOn", "Id", "Status" },
                values: new object[,]
                {
                    { (byte)3, "Create a ticket", "Red", new DateTime(2022, 12, 10, 21, 33, 43, 413, DateTimeKind.Utc).AddTicks(8376), new Guid("ba2b3a4b-754e-464b-b02d-faea77f0eeb0"), (byte)0 },
                    { (byte)1, "Request information", "Green", new DateTime(2022, 12, 10, 21, 33, 43, 413, DateTimeKind.Utc).AddTicks(8379), new Guid("5223633f-9b0f-4f54-8527-ff92dcfe2539"), (byte)0 }
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
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DataFill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Todo",
                columns: new[] { "Category", "Header", "Color", "CreatedOn", "Id", "Status" },
                values: new object[,]
                {
                    { (byte)3, "Create a ticket", "Red", new DateTime(2022, 12, 10, 13, 37, 31, 865, DateTimeKind.Utc).AddTicks(4741), 1, (byte)0 },
                    { (byte)1, "Request information", "Green", new DateTime(2022, 12, 10, 13, 37, 31, 865, DateTimeKind.Utc).AddTicks(4743), 2, (byte)0 }
                });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "Text", "TodoId" },
                values: new object[] { 1, "2-3шт.", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Todo",
                keyColumns: new[] { "Category", "Header" },
                keyValues: new object[] { (byte)1, "Request information" });

            migrationBuilder.DeleteData(
                table: "Todo",
                keyColumns: new[] { "Category", "Header" },
                keyValues: new object[] { (byte)3, "Create a ticket" });
        }
    }
}

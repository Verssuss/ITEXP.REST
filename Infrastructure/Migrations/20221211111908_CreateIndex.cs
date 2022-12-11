using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Todo_Id",
                table: "Todo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Todo",
                table: "Todo");

            //migrationBuilder.DeleteData(
            //    table: "Todo",
            //    keyColumns: new[] { "Category", "Header" },
            //    keyValues: new object[] { (byte)3, "Create a ticket" });

            //migrationBuilder.DeleteData(
            //    table: "Todo",
            //    keyColumns: new[] { "Category", "Header" },
            //    keyValues: new object[] { (byte)1, "Request information" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Todo",
                table: "Todo",
                column: "Id");

            //migrationBuilder.UpdateData(
            //    table: "Comment",
            //    keyColumn: "Id",
            //    keyValue: 1,
            //    column: "TodoId",
            //    value: new Guid("fa8aaa37-b319-471d-ad54-43757cc41863"));

            //migrationBuilder.InsertData(
            //    table: "Todo",
            //    columns: new[] { "Id", "Category", "Color", "CreatedOn", "Header", "Status" },
            //    values: new object[,]
            //    {
            //        { new Guid("f9d74be7-0cd1-4a66-8dbd-31ae952300a9"), (byte)1, "Green", new DateTime(2022, 12, 11, 11, 19, 8, 50, DateTimeKind.Utc).AddTicks(6931), "Request information", (byte)0 },
            //        { new Guid("fa8aaa37-b319-471d-ad54-43757cc41863"), (byte)3, "Red", new DateTime(2022, 12, 11, 11, 19, 8, 50, DateTimeKind.Utc).AddTicks(6920), "Create a ticket", (byte)0 }
            //    });

            migrationBuilder.CreateIndex(
                name: "IX_Todo_Header_Category",
                table: "Todo",
                columns: new[] { "Header", "Category" },
                unique: true);

            //migrationBuilder.InsertData(
            //    table: "Comment",
            //    columns: new[] { "Id", "Text", "TodoId" },
            //    values: new object[] { 1, "2-3шт.", new Guid("ba2b3a4b-754e-464b-b02d-faea77f0eeb0") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Todo",
                table: "Todo");

            migrationBuilder.DropIndex(
                name: "IX_Todo_Header_Category",
                table: "Todo");

            //migrationBuilder.DeleteData(
            //    table: "Todo",
            //    keyColumn: "Id",
            //    keyValue: new Guid("f9d74be7-0cd1-4a66-8dbd-31ae952300a9"));

            //migrationBuilder.DeleteData(
            //    table: "Todo",
            //    keyColumn: "Id",
            //    keyValue: new Guid("fa8aaa37-b319-471d-ad54-43757cc41863"));

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Todo_Id",
                table: "Todo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Todo",
                table: "Todo",
                columns: new[] { "Header", "Category" });

            //migrationBuilder.UpdateData(
            //    table: "Comment",
            //    keyColumn: "Id",
            //    keyValue: 1,
            //    column: "TodoId",
            //    value: new Guid("ba2b3a4b-754e-464b-b02d-faea77f0eeb0"));

            //migrationBuilder.InsertData(
            //    table: "Todo",
            //    columns: new[] { "Category", "Header", "Color", "CreatedOn", "Id", "Status" },
            //    values: new object[,]
            //    {
            //        { (byte)3, "Create a ticket", "Red", new DateTime(2022, 12, 10, 21, 33, 43, 413, DateTimeKind.Utc).AddTicks(8376), new Guid("ba2b3a4b-754e-464b-b02d-faea77f0eeb0"), (byte)0 },
            //        { (byte)1, "Request information", "Green", new DateTime(2022, 12, 10, 21, 33, 43, 413, DateTimeKind.Utc).AddTicks(8379), new Guid("5223633f-9b0f-4f54-8527-ff92dcfe2539"), (byte)0 }
            //    });

            //migrationBuilder.InsertData(
            //    table: "Comment",
            //    columns: new[] { "Id", "Text", "TodoId" },
            //    values: new object[] { 1, "2-3шт.", new Guid("ba2b3a4b-754e-464b-b02d-faea77f0eeb0") });
        }
    }
}

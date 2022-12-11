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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Todo",
                table: "Todo",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Todo_Header_Category",
                table: "Todo",
                columns: new[] { "Header", "Category" },
                unique: true);

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

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Todo_Id",
                table: "Todo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Todo",
                table: "Todo",
                columns: new[] { "Header", "Category" });

        }
    }
}

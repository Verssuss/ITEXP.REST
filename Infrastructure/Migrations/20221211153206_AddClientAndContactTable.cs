using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddClientAndContactTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientContact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false),
                    ContactType = table.Column<string>(type: "TEXT", nullable: false),
                    ContactValue = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientContact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientContact_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "Id", "ClientName" },
                values: new object[,]
                {
                    { 1, "Mikle" },
                    { 2, "John" }
                });

            migrationBuilder.InsertData(
                table: "Todo",
                columns: new[] { "Id", "Category", "Color", "CreatedOn", "Header", "Status" },
                values: new object[,]
                {
                    { new Guid("2c582e26-1773-47a8-8c82-da754dd30639"), (byte)1, "Green", new DateTime(2022, 12, 11, 15, 32, 5, 952, DateTimeKind.Utc).AddTicks(2689), "Request information", (byte)0 },
                    { new Guid("e46a7742-3d81-4ea0-b371-8bb5f37f2384"), (byte)3, "Red", new DateTime(2022, 12, 11, 15, 32, 5, 952, DateTimeKind.Utc).AddTicks(2686), "Create a ticket", (byte)0 }
                });

            migrationBuilder.InsertData(
                table: "ClientContact",
                columns: new[] { "Id", "ClientId", "ContactType", "ContactValue" },
                values: new object[,]
                {
                    { 1, 1, "SIM", "12345" },
                    { 2, 1, "SIM", "54321" },
                    { 3, 1, "SIM2", "33333" },
                    { 4, 2, "SIM", "756567" },
                    { 5, 2, "SIM2", "872364" }
                });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "Text", "TodoId" },
                values: new object[] { 1, "2-3шт.", new Guid("e46a7742-3d81-4ea0-b371-8bb5f37f2384") });

            migrationBuilder.CreateIndex(
                name: "IX_ClientContact_ClientId",
                table: "ClientContact",
                column: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientContact");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Todo",
                keyColumn: "Id",
                keyValue: new Guid("2c582e26-1773-47a8-8c82-da754dd30639"));

            migrationBuilder.DeleteData(
                table: "Todo",
                keyColumn: "Id",
                keyValue: new Guid("e46a7742-3d81-4ea0-b371-8bb5f37f2384"));
        }
    }
}

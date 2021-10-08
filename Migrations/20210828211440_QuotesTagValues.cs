using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace asping.Migrations
{
    public partial class QuotesTagValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 28, 22, 14, 40, 131, DateTimeKind.Local).AddTicks(3046));

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "General Description", "General" });

            migrationBuilder.InsertData(
                table: "QuoteTag",
                columns: new[] { "QuotesId", "TagsId" },
                values: new object[] { 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "QuoteTag",
                keyColumns: new[] { "QuotesId", "TagsId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 8, 28, 21, 17, 22, 813, DateTimeKind.Local).AddTicks(5814));
        }
    }
}

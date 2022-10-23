using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Asping.Migrations
{
    public partial class AddPredios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuoteTag_Quotes_QuotesQuoteId",
                table: "QuoteTag");

            migrationBuilder.DropForeignKey(
                name: "FK_QuoteTag_Tags_TagsTagId",
                table: "QuoteTag");

            migrationBuilder.RenameColumn(
                name: "TagId",
                table: "Tags",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TagsTagId",
                table: "QuoteTag",
                newName: "TagsId");

            migrationBuilder.RenameColumn(
                name: "QuotesQuoteId",
                table: "QuoteTag",
                newName: "QuotesId");

            migrationBuilder.RenameIndex(
                name: "IX_QuoteTag_TagsTagId",
                table: "QuoteTag",
                newName: "IX_QuoteTag_TagsId");

            migrationBuilder.RenameColumn(
                name: "QuoteId",
                table: "Quotes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Authors",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "Concelho",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codSF = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concelho", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Distrito",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcelhoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distrito", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Distrito_Concelho_ConcelhoId",
                        column: x => x.ConcelhoId,
                        principalTable: "Concelho",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Freguesia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DistritoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Freguesia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Freguesia_Distrito_DistritoId",
                        column: x => x.DistritoId,
                        principalTable: "Distrito",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Predio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FreguesiaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Predio_Freguesia_FreguesiaId",
                        column: x => x.FreguesiaId,
                        principalTable: "Freguesia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 23, 22, 39, 43, 727, DateTimeKind.Local).AddTicks(5326));

            migrationBuilder.CreateIndex(
                name: "IX_Distrito_ConcelhoId",
                table: "Distrito",
                column: "ConcelhoId");

            migrationBuilder.CreateIndex(
                name: "IX_Freguesia_DistritoId",
                table: "Freguesia",
                column: "DistritoId");

            migrationBuilder.CreateIndex(
                name: "IX_Predio_FreguesiaId",
                table: "Predio",
                column: "FreguesiaId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuoteTag_Quotes_QuotesId",
                table: "QuoteTag",
                column: "QuotesId",
                principalTable: "Quotes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuoteTag_Tags_TagsId",
                table: "QuoteTag",
                column: "TagsId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuoteTag_Quotes_QuotesId",
                table: "QuoteTag");

            migrationBuilder.DropForeignKey(
                name: "FK_QuoteTag_Tags_TagsId",
                table: "QuoteTag");

            migrationBuilder.DropTable(
                name: "Predio");

            migrationBuilder.DropTable(
                name: "Freguesia");

            migrationBuilder.DropTable(
                name: "Distrito");

            migrationBuilder.DropTable(
                name: "Concelho");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tags",
                newName: "TagId");

            migrationBuilder.RenameColumn(
                name: "TagsId",
                table: "QuoteTag",
                newName: "TagsTagId");

            migrationBuilder.RenameColumn(
                name: "QuotesId",
                table: "QuoteTag",
                newName: "QuotesQuoteId");

            migrationBuilder.RenameIndex(
                name: "IX_QuoteTag_TagsId",
                table: "QuoteTag",
                newName: "IX_QuoteTag_TagsTagId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Quotes",
                newName: "QuoteId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Authors",
                newName: "AuthorId");

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "QuoteId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 12, 27, 23, 45, 52, 781, DateTimeKind.Local).AddTicks(2350));

            migrationBuilder.AddForeignKey(
                name: "FK_QuoteTag_Quotes_QuotesQuoteId",
                table: "QuoteTag",
                column: "QuotesQuoteId",
                principalTable: "Quotes",
                principalColumn: "QuoteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuoteTag_Tags_TagsTagId",
                table: "QuoteTag",
                column: "TagsTagId",
                principalTable: "Tags",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

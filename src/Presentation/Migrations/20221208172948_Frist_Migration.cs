using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Presentation.Migrations
{
    public partial class Frist_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Death = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Distrito",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distrito", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    When = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AuthorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quotes_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Concelho",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DistritoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concelho", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Concelho_Distrito_DistritoId",
                        column: x => x.DistritoId,
                        principalTable: "Distrito",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuoteTag",
                columns: table => new
                {
                    QuotesId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuoteTag", x => new { x.QuotesId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_QuoteTag_Quotes_QuotesId",
                        column: x => x.QuotesId,
                        principalTable: "Quotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuoteTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuoteTags",
                columns: table => new
                {
                    QuoteId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuoteTags", x => new { x.QuoteId, x.TagId });
                    table.ForeignKey(
                        name: "FK_QuoteTags_Quotes_QuoteId",
                        column: x => x.QuoteId,
                        principalTable: "Quotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuoteTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
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
                    codSF = table.Column<int>(type: "int", nullable: false),
                    ConcelhoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Freguesia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Freguesia_Concelho_ConcelhoId",
                        column: x => x.ConcelhoId,
                        principalTable: "Concelho",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Predio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
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

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Birthday", "Death", "Name" },
                values: new object[,]
                {
                    { 1, null, null, "Albert Einstein" },
                    { 2, null, null, "Abraham Lincoln" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "General", "General" },
                    { 2, "Science", "Science" },
                    { 3, "Business", "Business" },
                    { 4, "Life", "Life" },
                    { 5, "History", "History" }
                });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "AuthorId", "CreatedAt", "Value", "When" },
                values: new object[] { 1, 2, new DateTime(2022, 12, 8, 17, 29, 47, 834, DateTimeKind.Local).AddTicks(8181), "America will never be destroyed from the outside", new DateTime(1838, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "AuthorId", "CreatedAt", "Value", "When" },
                values: new object[] { 2, 1, new DateTime(2022, 12, 8, 17, 29, 47, 842, DateTimeKind.Local).AddTicks(1872), "Two things are infinite: the universe and human stupidity; and I'm not sure about the universe.", null });

            migrationBuilder.InsertData(
                table: "QuoteTags",
                columns: new[] { "QuoteId", "TagId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 5 },
                    { 2, 1 },
                    { 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Concelho_DistritoId",
                table: "Concelho",
                column: "DistritoId");

            migrationBuilder.CreateIndex(
                name: "IX_Freguesia_ConcelhoId",
                table: "Freguesia",
                column: "ConcelhoId");

            migrationBuilder.CreateIndex(
                name: "IX_Predio_FreguesiaId",
                table: "Predio",
                column: "FreguesiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_AuthorId",
                table: "Quotes",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_QuoteTag_TagsId",
                table: "QuoteTag",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_QuoteTags_TagId",
                table: "QuoteTags",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Predio");

            migrationBuilder.DropTable(
                name: "QuoteTag");

            migrationBuilder.DropTable(
                name: "QuoteTags");

            migrationBuilder.DropTable(
                name: "Freguesia");

            migrationBuilder.DropTable(
                name: "Quotes");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Concelho");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Distrito");
        }
    }
}

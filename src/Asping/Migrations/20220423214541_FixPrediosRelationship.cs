using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Asping.Migrations
{
    public partial class FixPrediosRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Distrito_Concelho_ConcelhoId",
                table: "Distrito");

            migrationBuilder.DropForeignKey(
                name: "FK_Freguesia_Distrito_DistritoId",
                table: "Freguesia");

            migrationBuilder.DropIndex(
                name: "IX_Distrito_ConcelhoId",
                table: "Distrito");

            migrationBuilder.DropColumn(
                name: "ConcelhoId",
                table: "Distrito");

            migrationBuilder.RenameColumn(
                name: "DistritoId",
                table: "Freguesia",
                newName: "ConcelhoId");

            migrationBuilder.RenameIndex(
                name: "IX_Freguesia_DistritoId",
                table: "Freguesia",
                newName: "IX_Freguesia_ConcelhoId");

            migrationBuilder.AddColumn<int>(
                name: "DistritoId",
                table: "Concelho",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 23, 22, 45, 41, 400, DateTimeKind.Local).AddTicks(2966));

            migrationBuilder.CreateIndex(
                name: "IX_Concelho_DistritoId",
                table: "Concelho",
                column: "DistritoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Concelho_Distrito_DistritoId",
                table: "Concelho",
                column: "DistritoId",
                principalTable: "Distrito",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Freguesia_Concelho_ConcelhoId",
                table: "Freguesia",
                column: "ConcelhoId",
                principalTable: "Concelho",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Concelho_Distrito_DistritoId",
                table: "Concelho");

            migrationBuilder.DropForeignKey(
                name: "FK_Freguesia_Concelho_ConcelhoId",
                table: "Freguesia");

            migrationBuilder.DropIndex(
                name: "IX_Concelho_DistritoId",
                table: "Concelho");

            migrationBuilder.DropColumn(
                name: "DistritoId",
                table: "Concelho");

            migrationBuilder.RenameColumn(
                name: "ConcelhoId",
                table: "Freguesia",
                newName: "DistritoId");

            migrationBuilder.RenameIndex(
                name: "IX_Freguesia_ConcelhoId",
                table: "Freguesia",
                newName: "IX_Freguesia_DistritoId");

            migrationBuilder.AddColumn<int>(
                name: "ConcelhoId",
                table: "Distrito",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Distrito_Concelho_ConcelhoId",
                table: "Distrito",
                column: "ConcelhoId",
                principalTable: "Concelho",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Freguesia_Distrito_DistritoId",
                table: "Freguesia",
                column: "DistritoId",
                principalTable: "Distrito",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

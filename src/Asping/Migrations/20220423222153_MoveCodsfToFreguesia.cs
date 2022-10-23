using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Asping.Migrations
{
    public partial class MoveCodsfToFreguesia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "codSF",
                table: "Concelho");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Distrito",
                newName: "Nome");

            migrationBuilder.AddColumn<int>(
                name: "codSF",
                table: "Freguesia",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 23, 23, 21, 53, 196, DateTimeKind.Local).AddTicks(1655));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "codSF",
                table: "Freguesia");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Distrito",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "codSF",
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
        }
    }
}

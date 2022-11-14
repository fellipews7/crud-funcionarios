using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteLabs.Migrations
{
    public partial class AdicionandoCampoImagemFuncioario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Imagem",
                table: "Funcionarios",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagem",
                table: "Funcionarios");
        }
    }
}

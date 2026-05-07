using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeDo.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarTokenRecuperacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataExpiracaoToken",
                table: "Usuarios",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TokenRecuperacao",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataExpiracaoToken",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "TokenRecuperacao",
                table: "Usuarios");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeDo.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoMetasEStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dias",
                table: "Metas");

            migrationBuilder.AddColumn<bool>(
                name: "Domingo",
                table: "Metas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Quarta",
                table: "Metas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Quinta",
                table: "Metas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Sabado",
                table: "Metas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Segunda",
                table: "Metas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Sexta",
                table: "Metas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Terca",
                table: "Metas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "AtividadesDiarias",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Domingo",
                table: "Metas");

            migrationBuilder.DropColumn(
                name: "Quarta",
                table: "Metas");

            migrationBuilder.DropColumn(
                name: "Quinta",
                table: "Metas");

            migrationBuilder.DropColumn(
                name: "Sabado",
                table: "Metas");

            migrationBuilder.DropColumn(
                name: "Segunda",
                table: "Metas");

            migrationBuilder.DropColumn(
                name: "Sexta",
                table: "Metas");

            migrationBuilder.DropColumn(
                name: "Terca",
                table: "Metas");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "AtividadesDiarias");

            migrationBuilder.AddColumn<int>(
                name: "Dias",
                table: "Metas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

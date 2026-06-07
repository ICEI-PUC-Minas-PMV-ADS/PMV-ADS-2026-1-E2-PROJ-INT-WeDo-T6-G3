using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeDo.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarCamposNotificacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "Notificacoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Tipo",
                table: "Notificacoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Notificacoes_IdUsuario",
                table: "Notificacoes",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Notificacoes_Usuarios_IdUsuario",
                table: "Notificacoes",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notificacoes_Usuarios_IdUsuario",
                table: "Notificacoes");

            migrationBuilder.DropIndex(
                name: "IX_Notificacoes_IdUsuario",
                table: "Notificacoes");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Notificacoes");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Notificacoes");
        }
    }
}

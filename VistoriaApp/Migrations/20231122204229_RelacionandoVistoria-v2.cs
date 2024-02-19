using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VistoriaApp.Migrations
{
    /// <inheritdoc />
    public partial class RelacionandoVistoriav2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ambiente_Vistoriador_VistoriadorModelId",
                table: "Ambiente");

            migrationBuilder.DropForeignKey(
                name: "FK_Vistoriador_Vistoria_VistoriaId",
                table: "Vistoriador");

            migrationBuilder.DropIndex(
                name: "IX_Vistoriador_VistoriaId",
                table: "Vistoriador");

            migrationBuilder.DropIndex(
                name: "IX_Ambiente_VistoriadorModelId",
                table: "Ambiente");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Vistoriador");

            migrationBuilder.DropColumn(
                name: "VistoriaId",
                table: "Vistoriador");

            migrationBuilder.DropColumn(
                name: "VistoriadorModelId",
                table: "Ambiente");

            migrationBuilder.AddColumn<int>(
                name: "ImovelId",
                table: "Vistoria",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VistoriadorId",
                table: "Vistoria",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vistoria_ImovelId",
                table: "Vistoria",
                column: "ImovelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vistoria_VistoriadorId",
                table: "Vistoria",
                column: "VistoriadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vistoria_Imovel_ImovelId",
                table: "Vistoria",
                column: "ImovelId",
                principalTable: "Imovel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vistoria_Vistoriador_VistoriadorId",
                table: "Vistoria",
                column: "VistoriadorId",
                principalTable: "Vistoriador",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vistoria_Imovel_ImovelId",
                table: "Vistoria");

            migrationBuilder.DropForeignKey(
                name: "FK_Vistoria_Vistoriador_VistoriadorId",
                table: "Vistoria");

            migrationBuilder.DropIndex(
                name: "IX_Vistoria_ImovelId",
                table: "Vistoria");

            migrationBuilder.DropIndex(
                name: "IX_Vistoria_VistoriadorId",
                table: "Vistoria");

            migrationBuilder.DropColumn(
                name: "ImovelId",
                table: "Vistoria");

            migrationBuilder.DropColumn(
                name: "VistoriadorId",
                table: "Vistoria");

            migrationBuilder.AddColumn<int>(
                name: "Codigo",
                table: "Vistoriador",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VistoriaId",
                table: "Vistoriador",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VistoriadorModelId",
                table: "Ambiente",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vistoriador_VistoriaId",
                table: "Vistoriador",
                column: "VistoriaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ambiente_VistoriadorModelId",
                table: "Ambiente",
                column: "VistoriadorModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ambiente_Vistoriador_VistoriadorModelId",
                table: "Ambiente",
                column: "VistoriadorModelId",
                principalTable: "Vistoriador",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vistoriador_Vistoria_VistoriaId",
                table: "Vistoriador",
                column: "VistoriaId",
                principalTable: "Vistoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

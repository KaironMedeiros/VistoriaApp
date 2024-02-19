using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VistoriaApp.Migrations
{
    /// <inheritdoc />
    public partial class Criandotabelasv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Imovel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoImovel = table.Column<int>(type: "int", nullable: false),
                    Situacao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imovel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vistoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataVistoria = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MedidorAgua = table.Column<int>(type: "int", nullable: false),
                    MedidorEnergia = table.Column<int>(type: "int", nullable: false),
                    TipoVistoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vistoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rua = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImovelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Endereco_Imovel_ImovelId",
                        column: x => x.ImovelId,
                        principalTable: "Imovel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locatario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataSaida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImovelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locatario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locatario_Imovel_ImovelId",
                        column: x => x.ImovelId,
                        principalTable: "Imovel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vistoriador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VistoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vistoriador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vistoriador_Vistoria_VistoriaId",
                        column: x => x.VistoriaId,
                        principalTable: "Vistoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ambiente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comodo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SituacaoEletrica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReparoEletrica = table.Column<bool>(type: "bit", nullable: false),
                    ObsEletrica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SituacaoEsquadrias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReparoEsquadrias = table.Column<bool>(type: "bit", nullable: false),
                    ObsEsquadrias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SituacaoHidraulica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReparoHidraulica = table.Column<bool>(type: "bit", nullable: false),
                    ObsHidraulica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SituacaoPintura = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReparoPintura = table.Column<bool>(type: "bit", nullable: false),
                    ObsPintura = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SituacaoPiso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReparoPiso = table.Column<bool>(type: "bit", nullable: false),
                    ObsPiso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SituacaoTeto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReparoTeto = table.Column<bool>(type: "bit", nullable: false),
                    ObsTeto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VistoriaId = table.Column<int>(type: "int", nullable: false),
                    VistoriadorModelId = table.Column<int>(type: "int", nullable: true),
                    VistoriaModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ambiente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ambiente_Vistoria_VistoriaModelId",
                        column: x => x.VistoriaModelId,
                        principalTable: "Vistoria",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ambiente_Vistoriador_VistoriadorModelId",
                        column: x => x.VistoriadorModelId,
                        principalTable: "Vistoriador",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ambiente_VistoriadorModelId",
                table: "Ambiente",
                column: "VistoriadorModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Ambiente_VistoriaModelId",
                table: "Ambiente",
                column: "VistoriaModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_ImovelId",
                table: "Endereco",
                column: "ImovelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locatario_ImovelId",
                table: "Locatario",
                column: "ImovelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vistoriador_VistoriaId",
                table: "Vistoriador",
                column: "VistoriaId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ambiente");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Locatario");

            migrationBuilder.DropTable(
                name: "Vistoriador");

            migrationBuilder.DropTable(
                name: "Imovel");

            migrationBuilder.DropTable(
                name: "Vistoria");
        }
    }
}

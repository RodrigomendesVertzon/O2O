using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace O2OUI.Migrations
{
    public partial class teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CheckLicenses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataDeChecagem = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckLicenses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExcelConector",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false),
                    Ip = table.Column<string>(nullable: false),
                    DiretorioCompartilhado = table.Column<string>(nullable: false),
                    NomeArquivo = table.Column<string>(nullable: false),
                    Sheet = table.Column<string>(nullable: false),
                    Usuario = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true),
                    Identificador = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExcelConector", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MySqlConector",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false),
                    Ip = table.Column<string>(nullable: false),
                    Porta = table.Column<int>(nullable: false),
                    NomeDoBanco = table.Column<string>(nullable: false),
                    Usuario = table.Column<string>(nullable: false),
                    Senha = table.Column<string>(nullable: false),
                    Identificador = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MySqlConector", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OracleConector",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false),
                    Ip = table.Column<string>(nullable: false),
                    Porta = table.Column<int>(nullable: false),
                    NomeDoBanco = table.Column<string>(nullable: false),
                    Usuario = table.Column<string>(nullable: false),
                    Senha = table.Column<string>(nullable: false),
                    Identificador = table.Column<string>(nullable: false),
                    ServicesName = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OracleConector", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PermissaoDeAcessos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IpPermitido = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissaoDeAcessos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SNowConector",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: false),
                    Usuario = table.Column<string>(nullable: false),
                    Senha = table.Column<string>(nullable: false),
                    Identificador = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SNowConector", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SoapConectors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(nullable: false),
                    Usuario = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true),
                    Identificador = table.Column<string>(nullable: false),
                    TipoDeAutenticacao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoapConectors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SqlConectors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false),
                    Ip = table.Column<string>(nullable: false),
                    Porta = table.Column<int>(nullable: false),
                    NomeDoBanco = table.Column<string>(nullable: false),
                    Usuario = table.Column<string>(nullable: false),
                    Senha = table.Column<string>(nullable: false),
                    Identificador = table.Column<string>(nullable: false),
                    AutenticacaoWindows = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SqlConectors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Configurations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCL = table.Column<int>(nullable: false),
                    Valores = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configurations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConfigLabels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ConfigurationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigLabels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfigLabels_Configurations_ConfigurationId",
                        column: x => x.ConfigurationId,
                        principalTable: "Configurations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SdmStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSdm = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    StatusType = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SdmStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SdmConectors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: false),
                    Usuario = table.Column<string>(nullable: false),
                    Senha = table.Column<string>(nullable: false),
                    Identificador = table.Column<string>(nullable: false),
                    SdmStatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SdmConectors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SdmConectors_SdmStatus_SdmStatusId",
                        column: x => x.SdmStatusId,
                        principalTable: "SdmStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConfigLabels_ConfigurationId",
                table: "ConfigLabels",
                column: "ConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigLabels_Label",
                table: "ConfigLabels",
                column: "Label",
                unique: true,
                filter: "[Label] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Configurations_IdCL",
                table: "Configurations",
                column: "IdCL");

            migrationBuilder.CreateIndex(
                name: "IX_ExcelConector_Identificador",
                table: "ExcelConector",
                column: "Identificador",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MySqlConector_Identificador",
                table: "MySqlConector",
                column: "Identificador",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OracleConector_Identificador",
                table: "OracleConector",
                column: "Identificador",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SdmConectors_Identificador",
                table: "SdmConectors",
                column: "Identificador",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SdmConectors_SdmStatusId",
                table: "SdmConectors",
                column: "SdmStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_SdmStatus_IdSdm",
                table: "SdmStatus",
                column: "IdSdm");

            migrationBuilder.CreateIndex(
                name: "IX_SNowConector_Identificador",
                table: "SNowConector",
                column: "Identificador",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SoapConectors_Identificador",
                table: "SoapConectors",
                column: "Identificador",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SqlConectors_Identificador",
                table: "SqlConectors",
                column: "Identificador",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Configurations_ConfigLabels_IdCL",
                table: "Configurations",
                column: "IdCL",
                principalTable: "ConfigLabels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SdmStatus_SdmConectors_IdSdm",
                table: "SdmStatus",
                column: "IdSdm",
                principalTable: "SdmConectors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConfigLabels_Configurations_ConfigurationId",
                table: "ConfigLabels");

            migrationBuilder.DropForeignKey(
                name: "FK_SdmConectors_SdmStatus_SdmStatusId",
                table: "SdmConectors");

            migrationBuilder.DropTable(
                name: "CheckLicenses");

            migrationBuilder.DropTable(
                name: "ExcelConector");

            migrationBuilder.DropTable(
                name: "MySqlConector");

            migrationBuilder.DropTable(
                name: "OracleConector");

            migrationBuilder.DropTable(
                name: "PermissaoDeAcessos");

            migrationBuilder.DropTable(
                name: "SNowConector");

            migrationBuilder.DropTable(
                name: "SoapConectors");

            migrationBuilder.DropTable(
                name: "SqlConectors");

            migrationBuilder.DropTable(
                name: "Configurations");

            migrationBuilder.DropTable(
                name: "ConfigLabels");

            migrationBuilder.DropTable(
                name: "SdmStatus");

            migrationBuilder.DropTable(
                name: "SdmConectors");
        }
    }
}
